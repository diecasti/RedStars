using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonPiano : Buttom
{
    public minijuegoPiano juego;
    public int valor;


    public override void UseButtom()
    {

        juego.tocarTecla(valor);
       // base.UseButtom();
    }

}