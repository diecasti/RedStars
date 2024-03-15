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


    public int desiredX = 1000;
    public int desiredY = 2000;
    public int desiredZ = 5000;

    public bool goodX = false;
    public bool goodY = false;
    public bool goodZ = false;


    public TextMeshPro textoX;
    public TextMeshPro textoY;
    public TextMeshPro textoZ;


    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            //habilitar uin cursor, o que se haga mediante teclas? mejor un cursor en mi opinion
            //pero mientras tanto vamos a ponerlo con teclas

            //if (Input.GetKey(KeyCode.A))
            //{
            //    volanteX.localRotation *= Quaternion.AngleAxis(sensitivity * 1, Vector3.up);
            //}
            //if (Input.GetKey(KeyCode.S))
            //{
            //    volanteY.localRotation *= Quaternion.AngleAxis(sensitivity * 1, Vector3.up);
            //}
            //if (Input.GetKey(KeyCode.D))
            //{
            //    volanteZ.localRotation *= Quaternion.AngleAxis(sensitivity * 1, Vector3.up);
            //}



        }

        
        textoX.text = "X desired " + desiredX + "\nX Angle: " + volanteX.valor;
        textoY.text = "Y desired " + desiredY + "\nY Angle: " + volanteY.valor;
        textoZ.text = "Z desired " + desiredZ + "\nZ Angle: " + volanteZ.valor;
        //Debug.Log("direction " + checkDirection());


    }


    public bool checkDirection()
    {

            goodX = Mathf.Abs(desiredX - volanteX.valor) <= 10;
            goodY = Mathf.Abs(desiredY - volanteY.valor) <= 10;
            goodZ = Mathf.Abs(desiredZ - volanteZ.valor) <= 10;

        return (goodX && goodY && goodZ);
    }


}
