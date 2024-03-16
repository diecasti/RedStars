using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minijuegoPiano : MonoBehaviour
{

    public List<int> secuencia;
    public int aciertos = 0;
    public int alteracion = 0;

    public void tocarTecla(int valor)
    {
        if (secuencia[aciertos] == valor)
        {
            //acierto
            aciertos++;
        }
        else
        {
            //TODO error
            aciertos = 0;
            //emitir algun sonido
        }
        

        if (aciertos >= secuencia.Count)
        {
            //se termino
            //TODO lanzar evento de terminar piano
            aciertos = 0;

            Debug.Log("piano complete");

            alteracion--;
            if (alteracion < 0) alteracion = 0;
        }
    }
}
