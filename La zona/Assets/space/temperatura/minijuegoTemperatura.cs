using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class minijuegoTemperatura : MonoBehaviour
{

    public int temperatura = 23; //centigrados, me da igual todo
    public int calor = 0; //puede estar en positivo o negativo
    public int ganancia = -6; //que temperatura le vamos a sumar cada X tiempo de forma aleatoria,. para que ahya jugabilidad, o no,. que los jugadores se destruyan ellos solos


    public float clock = 40.0f;
    public float targetTime = 40.0f;



    public TextMeshPro temAct;
    public TextMeshPro texSumar;
    public GameObject icono;


    public void addCalor(int a)
    {

        calor += a;
        calor = Mathf.Clamp(calor, -8, 8);
    }


    private void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            temperatura += calor + ganancia;
            targetTime = clock;

            temAct.text = temperatura + "�C";

            if (temperatura < 10)
            {
                icono.SetActive(true);
            }
            else
            {
                icono.SetActive(false);
            }
        }
    }
}
