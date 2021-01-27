using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class CrearEscenario : MonoBehaviour
{
    public GameObject bajar;
    public GameObject izq;
    public GameObject checkPoint;
    public GameObject vayaVertical;
    public GameObject vayaHorizontal;
    public Enemy enemigo;
    public int alto;
    public int ancho;
    public int repetir;
    public int apoyo;
    public int cambioDeDireccion;
    public List<GameObject> checkPoints= new List<GameObject>();
    

    public int[,] casillas;

    // Start is called before the first frame update
    void Start()
    {
        apoyo = 0;
        casillas = new int[alto, ancho];
        //Generar Path del enemigo
        for (int i = 0; i < alto; i++)
        {

            for (int j = apoyo; j < ancho; j++)
            {

                casillas[i, apoyo] = 1;

                if (casillas[i, apoyo] == 1)
                {
                    
                    repetir = Random.Range(-1, 2);
                    
                    if (repetir != cambioDeDireccion)
                    {
                        checkPoints.Add(Instantiate(checkPoint,new Vector3(apoyo, 0,-i), Quaternion.identity));
                    }
                    cambioDeDireccion = repetir;

                    switch (repetir)
                    {
                       case -1:
                           Instantiate(bajar, new Vector3(apoyo, 0,-i), Quaternion.identity);
                           break;
                       case 0:
                           Instantiate(bajar, new Vector3(apoyo, 0,-i), Quaternion.identity);
                           break; 
                       case 1:
                           Instantiate(bajar, new Vector3(apoyo, 0,-i), Quaternion.identity);
                           break;
                           
                    }
                    
                    
                    
                    j = apoyo;
                    
                    
                    
                    switch (repetir)
                    {
                        case 0:
                            j = ancho;
                            break;

                        
                        
                        
                        case -1:
                            
                            if (apoyo > 0)
                            {
                                if (apoyo < ancho-1)
                                {
                                    if (casillas[i, apoyo - 1] != 1)
                                    {
                                        apoyo--;
                                        j = apoyo;
                                    }else
                                    {
                                        j = ancho;
                                    }
                                }

                                if (apoyo == ancho)
                                {
                                    if(casillas[i, apoyo - 1] != 1)
                                    {
                                        apoyo--;
                                        j = apoyo;
                                    }else
                                    {
                                        j = ancho;
                                    }
                                }
                            }else
                            {
                                j = ancho;
                            }

                            break;

                        
                        
                        
                        case 1:

                            if (apoyo < ancho-1)
                            {
                                if (apoyo > 0)
                                {
                                    if (casillas[i, apoyo + 1] != 1)
                                    {
                                        apoyo++;
                                        j = apoyo;
                                    }else
                                    {
                                        j = ancho;
                                    }
                                }

                                if (apoyo == 0)
                                {
                                    if(casillas[i, apoyo + 1] != 1)
                                    {
                                        apoyo++;
                                        j = apoyo;
                                    }else
                                    {
                                        j = ancho;
                                    }
                                }
                            }else
                            {
                                j = ancho;
                            }

                            break;

                    }
                }
            }
        }
        
        
        //vayar Perimetro
        for (int i = -1; i < alto+1; i++)
        {
            for (int j = -1; j < ancho+1; j++)
            {
              if (i == -1 || i == alto)
              {
                  Instantiate(vayaHorizontal, new Vector3(j, 0, -i), Quaternion.identity);
              }
              else {
                  Instantiate(izq, new Vector3(j, 0, -i), Quaternion.identity);
              }

              if (i != -1 && i != alto )
              {
                  if (j == -1 || j == ancho )
                  {
                      Instantiate(vayaVertical, new Vector3(j, 0, -i), Quaternion.identity);
                  }
              }
            }
        }
        
        enemigo.gameObject.SetActive(true);
    }
}






