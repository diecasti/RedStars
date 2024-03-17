using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class minijuegoGases : minijuego
{
    public float Oxigeno = 21*4;
    public float Nitrogeno = 78*4;
    public float CO2 = 1*4;

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

    public GameObject icon;


    public TextMeshPro texto;



    private void Start()
    {
        IEnumerator rutina = jeje();
        StartCoroutine(rutina);
    }

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
        //vamos a asignarle los medidores ya porque xd
        //van a ser texto que pereza
        texto.text = "O2    : " + Operct + "    %\nCO2  : " + COperct + "   %\nN   : " + Nperct + " %";
    }

    

    IEnumerator jeje()
    {
        while (true)
        {
            if (Operct < 18 || Operct > 24 || Nperct < 60 || Nperct > 80)
            {
                icon.SetActive(true);
            }
            else
            {
                icon.SetActive(false);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
