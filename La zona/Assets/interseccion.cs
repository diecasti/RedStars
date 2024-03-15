using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interseccion : MonoBehaviour
{

    public bool iz;
    public bool der;

    public int izCOunt;
    public int derCout;

    public Transform LastDerecha;
    public Transform LastIz;

    public Transform RetrunDer;
    public Transform Retruniz;

    // Update is called once per frame


    public void putLastDerecha(Transform child)
    {
        //Debug.Log("derecha");

        child.rotation = LastDerecha.rotation; //esto es por si, resulta que la ultima tile era la de una interseccion, porque aun ni idea de como voy a hacer para instanciarlas
        if (LastDerecha.GetComponent<MeshFilter>())
        {
            child.position = LastDerecha.position - (LastDerecha.forward * ((child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z) + (LastDerecha.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * LastDerecha.localScale.z)));
        }
        else
        {
            child.position = LastDerecha.position - (LastDerecha.forward * (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z));
        }
        LastDerecha = child;
        derCout++;
    }
    public void putLastIzquiuerda(Transform child)
    {
        child.rotation = LastIz.rotation; //esto es por si, resulta que la ultima tile era la de una interseccion, porque aun ni idea de como voy a hacer para instanciarlas

            //Debug.Log("izquierda");
        if (LastIz.GetComponent<MeshFilter>())
        {
            child.position = LastIz.position - (LastIz.forward * ((child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z) + (LastIz.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * LastIz.localScale.z)));
        }
        else
        {
            child.position = LastIz.position - (LastIz.forward * (child.GetComponent<MeshFilter>().sharedMesh.bounds.max.z * child.localScale.z));
        }
        LastIz = child;
        izCOunt++;
    }

    public void resetIntereseccion()
    {
        LastDerecha = RetrunDer;
        LastIz = Retruniz;
        izCOunt = 0;
        derCout = 0;
    }

}
