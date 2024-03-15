using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidad = 0;

    public GameObject Mundo; //es el mundo el que se mueve, los hijos que contiene son los que se acercan hacia el jugador, y desaparecen una vez detras de la camara
    public GameObject LastTile;  //a esta tile es a la que le vamos a asignar el siguiente de las tiles cuando esta haya desaparecido detras de la camara, para ello usare las dimensiones del plano, y de la que ase va a eliminar
    public GameObject NextLastTile;  //a esta tile es a la que le vamos a asignar el siguiente de las tiles cuando esta haya desaparecido detras de la camara, para ello usare las dimensiones del plano, y de la que ase va a eliminar
    public Transform player;

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

                            putTileInFront(child);
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

                            putTileInFront(child);
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

                            putTileInFront(child);
                            frontIntersectCount++;
                        }
                        else
                        {
                            interesecciones[0].putLastIzquiuerda(child);
                        }
                    }
                    else
                    {
                        putTileInFront(child);
                    }
                }
                else
                {

                    putTileInFront(child);
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


    public void putTileInFront(Transform child)
    {
        Transform lasttras = LastTile.transform;




        child.rotation = lasttras.rotation; //esto es por si, resulta que la ultima tile era la de una interseccion, porque aun ni idea de como voy a hacer para instanciarlas

        if (LastTile.GetComponent<MeshFilter>())
        {
            child.position = lasttras.position - new Vector3(0.0f, 0.0f, (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z) + (LastTile.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * lasttras.localScale.z));
        }
        else
            child.position = LastTile.transform.position - (LastTile.transform.forward * (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z));

        LastTile = child.gameObject;
    }


    public void girarMundo(bool der)
    {


        //esot es una barbaridad, necesitas una animacion acorde a la velocidad,
        //la velocidad del giro dependera de la velocidad
        //como hacer un giro

       
        

        IEnumerator rutina;

        if (der)
        {
            

            var rotation = Quaternion.LookRotation(-Mundo.transform.right, Mundo.transform.up);

            rutina = TurnWagon(rotation, der);
            StartCoroutine(rutina);
            //Mundo.transform.Rotate(0,90,0);
            //la z de todos los hijos tinee que ser 0
        }
        else
        {

            //LastTile = interesecciones[0].LastIz.gameObject;
            var rotation = Quaternion.LookRotation(Mundo.transform.right, Mundo.transform.up);

            rutina = TurnWagon(rotation, der);
            StartCoroutine(rutina);
            //Mundo.transform.Rotate(0, -90, 0);
            //la z de todos los hijos tiene que ser 0 //al ser objetos vacios
        }

        //TODO aqui hay que mirar si elimino las intersecciones o como las continuo
        foreach (var a in interesecciones)
        {
            a.resetIntereseccion();
        }
    }

    private IEnumerator TurnWagon(Quaternion RotDesired, bool der)
    {

        while (interesecciones[0].transform.position.z <= 0)
        {
            Debug.Log("llegando a la interseccion");
            yield return new WaitForFixedUpdate();
        }


        //interesecciones[0].transform.position = new vect;

        LastTile =  der ? interesecciones[0].LastDerecha.gameObject : interesecciones[0].LastIz.gameObject;

        while (Quaternion.Angle(Mundo.transform.rotation, RotDesired) >= 0.05f)
        {
            Debug.Log("girando");
            Mundo.transform.rotation = Quaternion.Lerp(Mundo.transform.rotation, RotDesired, velocidad * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        Mundo.transform.rotation = RotDesired;

        //TODO, como esoty haciendo el giro en cualquier parte pues pasa que las tiles no quedan centradas
        //forazando la maquina a que las tiles queden en el medio (se ve raro)
        //foreach (Transform child in Mundo.transform)
        //{
        //    //Vector3 posicionRot = new Vector3(0, child.position.y, child.position.z);

        //    child.position = new Vector3(0, child.position.y, child.position.z);
        //}
    }

}
