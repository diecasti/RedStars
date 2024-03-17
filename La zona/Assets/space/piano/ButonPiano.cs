using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonPiano : Buttom
{
    public minijuegoPiano juego;
    public int valor;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void UseButtom()
    {

        juego.tocarTecla(valor);
        audio.Play();
    }

}