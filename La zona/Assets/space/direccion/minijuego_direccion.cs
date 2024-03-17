using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class minijuego_direccion : minijuego
{

    public Vector3 direccion;

    public Wheel volanteX;
    public Wheel volanteY;
    public Wheel volanteZ;

    public float sensitivity = 5;


    public int desiredX = 500;
    public int desiredY = 200;
    public int desiredZ = 900;

    public bool goodX = false;
    public bool goodY = false;
    public bool goodZ = false;


    //public TextMeshPro textoX;
    //public TextMeshPro textoY;
    //public TextMeshPro textoZ;



    //para poner los indicadores de la dirección
    public Transform marcadorObjetivoX;
    public Transform marcadorObjetivoY;
    public Transform marcadorObjetivoZ;

    public Transform marcadorX;
    public Transform marcadorY;
    public Transform marcadorZ;

    public Transform marcaX;
    public Transform marcaY;
    public Transform marcaZ;

    public GameObject icon;


    
    IEnumerator jeje()
    {
        while (true)
        {
            if (checkDirection())
            {
                icon.SetActive(false);
            }
            else
            {
                icon.SetActive(true);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
       
    public void putMarks()
    {
        Vector3 a = marcaX.GetComponent<MeshFilter>().mesh.bounds.size;

        marcadorObjetivoX.localPosition = new Vector3((marcaX.localPosition.x - marcaX.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaX.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)desiredX) / 1000.0f), marcaX.localPosition.y, marcaX.localPosition.z);
        a = marcaY.GetComponent<MeshFilter>().mesh.bounds.size;
        marcadorObjetivoY.localPosition = new Vector3((marcaY.localPosition.x - marcaY.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaY.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)desiredY) / 1000.0f), marcaY.localPosition.y, marcaY.localPosition.z);
        a = marcaZ.GetComponent<MeshFilter>().mesh.bounds.size;
        marcadorObjetivoZ.localPosition = new Vector3((marcaZ.localPosition.x - marcaZ.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaZ.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)desiredZ) / 1000.0f), marcaZ.localPosition.y, marcaZ.localPosition.z);
        
        marcadorX.localPosition = new Vector3((marcaX.localPosition.x - marcaX.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaX.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)volanteX.valor) / 1000.0f), marcaX.localPosition.y, marcaX.localPosition.z);
        a = marcaY.GetComponent<MeshFilter>().mesh.bounds.size;
        marcadorY.localPosition = new Vector3((marcaY.localPosition.x - marcaY.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaY.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)volanteY.valor) / 1000.0f), marcaY.localPosition.y, marcaY.localPosition.z);
        a = marcaZ.GetComponent<MeshFilter>().mesh.bounds.size;
        marcadorZ.localPosition = new Vector3((marcaZ.localPosition.x - marcaZ.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaZ.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)volanteZ.valor) / 1000.0f), marcaZ.localPosition.y, marcaZ.localPosition.z);


    }


    private void Start()
    {
        IEnumerator rutina = jeje();
        StartCoroutine(rutina);

        putMarks();
    }
    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            Vector3 a = marcaX.GetComponent<MeshFilter>().mesh.bounds.size;

            marcadorX.localPosition = new Vector3((marcaX.localPosition.x - marcaX.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaX.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)volanteX.valor) / 1000.0f), marcaX.localPosition.y, marcaX.localPosition.z);
            a = marcaY.GetComponent<MeshFilter>().mesh.bounds.size;
            marcadorY.localPosition = new Vector3((marcaY.localPosition.x - marcaY.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaY.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)volanteY.valor) / 1000.0f), marcaY.localPosition.y, marcaY.localPosition.z);
            a = marcaZ.GetComponent<MeshFilter>().mesh.bounds.size;
            marcadorZ.localPosition = new Vector3((marcaZ.localPosition.x - marcaZ.GetComponent<MeshFilter>().mesh.bounds.size.x / 4.0f) + (marcaZ.GetComponent<MeshFilter>().mesh.bounds.size.x / 2.0f * ((float)volanteZ.valor) / 1000.0f), marcaZ.localPosition.y, marcaZ.localPosition.z);
        }
            




    }


    public bool checkDirection()
    {

        goodX = Vector3.Distance(marcadorObjetivoX.position, marcadorX.position) <= 0.1;
        goodY = Vector3.Distance(marcadorObjetivoY.position, marcadorY.position) <= 0.1;
        goodZ = Vector3.Distance(marcadorObjetivoZ.position, marcadorZ.position) <= 0.1;

        return (goodX && goodY && goodZ);
    }


}