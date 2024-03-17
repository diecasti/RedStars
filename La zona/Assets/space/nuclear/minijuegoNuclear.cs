using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minijuegoNuclear : minijuego
{

    public float clock = 120.0f;
    public float targetTime = 120.0f;

    public int barrasDentro = 3;

    public GameObject icon;
    public AudioSource audio;
  
    IEnumerator empezado()
    {
        yield return new WaitForSeconds(30.0f);
    }

    private void FixedUpdate()
    {
        if (barrasDentro < 3)
        {
            if (!audio.isPlaying)
                audio.Play();
            icon.SetActive(true);
            targetTime -= (Time.deltaTime / (float)(barrasDentro + 1));

            if (targetTime <= 0.0f)
            {
                //TODO hay que ahcer algo cuando se pierde el minijuego este
                targetTime = clock;
            }
        }
        if (barrasDentro == 3)
        {
            if (audio.isPlaying)
                audio.Stop();
            icon.SetActive(false);
            targetTime = clock;
        }
    }
}
