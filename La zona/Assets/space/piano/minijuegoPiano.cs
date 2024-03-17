using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minijuegoPiano : MonoBehaviour
{

    public List<int> secuencia;
    public int aciertos;
    public int alteracion;

    public GameObject pulso1; //empieza active
    public GameObject pulso2;
    public GameObject pulso3;

    public List<AudioSource> latido;
    public AudioSource silvido;


    private void Start()
    {
        IEnumerator rutina = alterar();
        StartCoroutine(rutina); 
        IEnumerator late = latidos();
        StartCoroutine(late);
        setPulso();
    }
    
    IEnumerator latidos()
    {
        while (true)
        {
            for (int i = 0; i < alteracion && i < 3; i++)
            {
                latido[i].PlayScheduled(1f/ (float)(1+ alteracion-i));
            }
            yield return new WaitForSeconds(1f);
        }
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

            relajar();
            Debug.Log("piano complete");
            silvido.PlayScheduled(3.0f);

        }
    }

    public void relajar()
    {
        alteracion--;
        alteracion = Mathf.Clamp(alteracion, 0, 4);
        if (alteracion == 0)
        {
            silvido.PlayScheduled(3.0f);
        }
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
