using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minijuegoGases : minijuego
{
    public float Oxigeno = 210;
    public float Nitrogeno = 780;
    public float CO2 = 10;

    //ganancia por segundo
    public float OxGain;
    public float CO2Gain;

    //se permite una discrepancia en ambos del 10%
    public int OWanted = 21;
    public int NWanted = 78;
    public int c02Wanted = 11;

    public int Operct;
    public int COperct;
    public int Nperct;

    private void FixedUpdate()
    {

        //50 veces por segundo
        Oxigeno += OxGain /50.0f;
        CO2 += CO2Gain / 50.0f;
    }

    private void Update()
    {
        //calcular el porcentage de cada elemento

        float total = Oxigeno + Nitrogeno + CO2;

         Operct = (int) ((Oxigeno/total) * 100);
         COperct = (int)((CO2 / total) * 100);
         Nperct = (int)((Nitrogeno / total) * 100);

        //TODO  asignar luego esos porcentages a unos medidores


    }

}
