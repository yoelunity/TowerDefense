using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CrearEscenario mapa;
    public float t;
    public float factorT;
    public Vector3 actualPoint;
    public Vector3 nextPoint;
    public int indiceActual;
    public float speed;

    public void Start()
    {
        t = 1f;
    }

    private void Update()
    {
        if (indiceActual < mapa.checkPoints.Count)
        {
            t += factorT * Time.deltaTime;
            if (t >= 1f)
            {
                indiceActual++;
                if (indiceActual == mapa.checkPoints.Count - 1)
                {
                    indiceActual = 0;
                }

                CalcularValores();
            }

            transform.position = Vector3.Lerp(new Vector3(actualPoint.x, 1.5f, actualPoint.z),
                new Vector3(nextPoint.x, 1.5f, nextPoint.z), t);

        }

        if (indiceActual > mapa.checkPoints.Count)
        {
            Destroy(this);
        }
    }

    void CalcularValores()
    {
        actualPoint = mapa.checkPoints[indiceActual-1].transform.position;
        nextPoint = mapa.checkPoints[indiceActual].transform.position;
        t = 1.0f - t;
        factorT = 1.0f / Vector3.Distance(actualPoint, nextPoint) * speed;
    }
    }

    

