using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minijuego_direccion : minijuego
{

    public Vector3 direccion;

    public Transform volanteX;
    public Transform volanteY;
    public Transform volanteZ;

    public float sensitivity = 5;


    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            //habilitar uin cursor, o que se haga mediante teclas? mejor un cursor en mi opinion
            //pero mientras tanto vamos a ponerlo con teclas

            if (Input.GetKey(KeyCode.A))
            {
                volanteX.localRotation *= Quaternion.AngleAxis(sensitivity * 1, Vector3.up);
            }
            if (Input.GetKey(KeyCode.S))
            {
                volanteY.localRotation *= Quaternion.AngleAxis(sensitivity * 1, Vector3.up);
            }
            if (Input.GetKey(KeyCode.D))
            {
                volanteZ.localRotation *= Quaternion.AngleAxis(sensitivity * 1, Vector3.up);
            }

        }
    }
}
