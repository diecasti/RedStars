using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class valvula : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum gas { O, N, Co2 };

    bool selected;
    public int valor;
    public gas tipo;
    public minijuegoGases juego;
    AudioSource audio;
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

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {

        if (selected)
        {

            if (!audio.isPlaying)
            {
                audio.Play();
            }

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
        else
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }
    }

}

