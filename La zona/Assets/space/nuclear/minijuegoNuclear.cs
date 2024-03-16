using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minijuegoNuclear : minijuego
{

    public float clock = 120.0f;
    public float targetTime = 120.0f;

    public int barrasDentro = 3;




    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (barrasDentro < 3)
        {
            targetTime -= (Time.deltaTime / (float)(barrasDentro + 1));

            if (targetTime <= 0.0f)
            {
                targetTime = clock;
            }
        }
        if (barrasDentro == 3)
        {
            targetTime = clock;
        }
    }
}
