using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempbuttom : Buttom
{

    public minijuegoTemperatura juego;
    public bool calor;
    public AudioSource sound;
    public override void UseButtom()
    {
        sound.Play();
        Debug.Log("temperatura botom");
        juego.addCalor(calor ? 1 : -1);


        juego.texSumar.text = ((juego.calor > 0) ? "+": "") + juego.calor + "ºC";
    }
}
