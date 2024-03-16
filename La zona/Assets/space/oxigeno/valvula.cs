using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class valvula : MonoBehaviour
{
    public enum gas { O, N, Co2 };

    bool selected;
    public int valor;
    public gas tipo;
    public minijuegoGases juego;
    public void OnPointerClick(PointerEventData eventData)
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;
    }

    private void FixedUpdate()
    {

        if (selected)
        {
            switch (tipo)
            {
                case gas.O:
                    {
                        juego.Oxigeno += valor / 50.0f;
                    }
                    break;
                case gas.N:
                    {
                        juego.Nitrogeno += valor / 50.0f;
                    }
                    break;
                case gas.Co2:
                    {
                        juego.CO2 += valor / 50.0f;
                    }
                    break;
                default: break;
            }
        }
    }

}

