using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearGoodTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public minijuegoNuclear juego;
    public barraNuclear barra;


    public float clock = 120.0f;
    public float targetTime = 120.0f;

    private void OnTriggerEnter(Collider other)
    {
        barraNuclear a = other.GetComponent<barraNuclear>();
        if (a)
        {
            if (!barra)
            {
                barra = a;
                juego.barrasDentro++;
                a.selected = false;
            }
            else if (barra)
            {
                a.spawnBarra();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        barraNuclear a = other.GetComponent<barraNuclear>();
        if (a)
        {
            if (barra == a)
            {
                barra = null;
                juego.barrasDentro--;
            }
        }
    }

    private void FixedUpdate()
    {
        if (barra)
        {
            //expulsarla a los dos minutos

            targetTime -= 1.0f/50.0f;

            if (targetTime <= 0.0f)
            {
                targetTime = clock;
                barra.spawnBarra();
                juego.barrasDentro--;
                barra = null;
            }
        }
    }
}
