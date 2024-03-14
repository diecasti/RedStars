using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidad = 0;

    public GameObject Mundo; //es el mundo el que se mueve, los hijos que contiene son los que se acercan hacia el jugador, y desaparecen una vez detras de la camara
    public GameObject LastTile;  //a esta tile es a la que le vamos a asignar el siguiente de las tiles cuando esta haya desaparecido detras de la camara, para ello usare las dimensiones del plano, y de la que ase va a eliminar


    public List<interseccion> interesecciones; //esta lsita nos dice las interesecciones que hay por delante, y por tanto si necesitan tiles para construirse o no
    public int frontIntersectCount; //cuantas tiles hay hacia adelante de la interseccion

    void Update()
    {
        foreach (Transform child in Mundo.transform)
        {
            if (child.position.z >= transform.position.z) // la tile esta detras de la camara
            {
               
                

                //posicionamos la tile al siguiente
                //la rotacion debe de ser la misma si no la liamos bastisimo, van a ser siempre la misma, supongo, digo yo??, puede que no

                Transform lasttras = LastTile.transform;
                
                if (child.GetComponent<interseccion>())
                {
                    frontIntersectCount = 0;
                    child.GetComponent<interseccion>().resetIntereseccion();
                }

                if (interesecciones.Count > 0 && !child.GetComponent<interseccion>())
                {
                    if (interesecciones[0].der && interesecciones[0].iz)
                    {
                        if (frontIntersectCount <= Mathf.Max(interesecciones[0].derCout, interesecciones[0].izCOunt))
                        {
                            child.rotation = lasttras.rotation; //esto es por si, resulta que la ultima tile era la de una interseccion, porque aun ni idea de como voy a hacer para instanciarlas
                            child.position = lasttras.position - new Vector3(0.0f, 0.0f, (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z) + (LastTile.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * lasttras.localScale.z));
                            LastTile = child.gameObject;
                            frontIntersectCount++;
                        }
                        else
                        {
                            if (interesecciones[0].derCout <= interesecciones[0].izCOunt)
                            {
                                interesecciones[0].putLastDerecha(child);
                            }
                            else
                            {
                                interesecciones[0].putLastIzquiuerda(child);
                            }
                        }
                    }
                    else if (interesecciones[0].der && !interesecciones[0].iz)
                    {
                        if (frontIntersectCount <= interesecciones[0].derCout)
                        {
                            child.rotation = lasttras.rotation; //esto es por si, resulta que la ultima tile era la de una interseccion, porque aun ni idea de como voy a hacer para instanciarlas
                            child.position = lasttras.position - new Vector3(0.0f, 0.0f, (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z) + (LastTile.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * lasttras.localScale.z));
                            LastTile = child.gameObject;
                            frontIntersectCount++;
                        }
                        else
                        {
                             interesecciones[0].putLastDerecha(child);
                        }
                    }
                    else if(!interesecciones[0].der && interesecciones[0].iz)
                    {
                        if (frontIntersectCount <= interesecciones[0].izCOunt)
                        {
                            child.rotation = lasttras.rotation; //esto es por si, resulta que la ultima tile era la de una interseccion, porque aun ni idea de como voy a hacer para instanciarlas
                            child.position = lasttras.position - new Vector3(0.0f, 0.0f, (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z) + (LastTile.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * lasttras.localScale.z));
                            LastTile = child.gameObject;
                            frontIntersectCount++;
                        }
                        else
                        {
                            interesecciones[0].putLastIzquiuerda(child);
                        }
                    }
                    else
                    {
                        child.rotation = lasttras.rotation; //esto es por si, resulta que la ultima tile era la de una interseccion, porque aun ni idea de como voy a hacer para instanciarlas
                        child.position = lasttras.position - new Vector3(0.0f, 0.0f, (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z) + (LastTile.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * lasttras.localScale.z));
                        LastTile = child.gameObject;
                    }
                }
                else
                {
                    child.rotation = lasttras.rotation; //esto es por si, resulta que la ultima tile era la de una interseccion, porque aun ni idea de como voy a hacer para instanciarlas
                    child.position = lasttras.position - new Vector3(0.0f, 0.0f, (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z) + (LastTile.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * lasttras.localScale.z));
                    LastTile = child.gameObject;
                }


            }
  
        }
    }

    //tomar una intersección, rotar la camara con un ler acorde a la velocidad que llevemos y a lo ajustado que ha sido la intersección
    private void FixedUpdate()
    {
        foreach (Transform child in Mundo.transform)
        {
            child.position += Vector3.forward * Time.deltaTime * velocidad;
        }

    }
}
