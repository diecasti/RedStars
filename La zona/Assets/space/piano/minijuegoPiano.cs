using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minijuegoPiano : MonoBehaviour
{

    public List<int> secuencia;
    public int aciertos = 0;
    public int alteracion = 0;

    public GameObject pulso1; //empieza active
    public GameObject pulso2;
    public GameObject pulso3;



    private void Start()
    {
        IEnumerator rutina = alterar();
        StartCoroutine(rutina);
        setPulso();
    }
    


    IEnumerator alterar()
    {

        while (true)
        {

            //TODO aqui se altera a la unidad

            //TODO añadir sonidos de alterado?
            yield return new WaitForSeconds(Random.Range(30.0f, 60.0f));
            alteracion++;
            alteracion = Mathf.Clamp(alteracion, 0, 4);
            setPulso();
        }

        yield return null;
    }



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

            relajar();
        }
    }

    public void relajar()
    {
        alteracion--;
        alteracion = Mathf.Clamp(alteracion, 0, 4);
        setPulso();
        //Lanzar eventos de sonido
    }

    public void setPulso() {
    
        switch (alteracion)
        {
            case 0:
                pulso1.SetActive(true);
                pulso2.SetActive(false);
                pulso3.SetActive(false);
                break;
            case 2:
                pulso1.SetActive(false);
                pulso2.SetActive(true);
                pulso3.SetActive(false);
                break;
            case 3:
                pulso1.SetActive(false);
                pulso2.SetActive(false);
                pulso3.SetActive(true);
                break;
        }
    
    }
}
