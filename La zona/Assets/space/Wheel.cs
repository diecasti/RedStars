
using UnityEngine;
using UnityEngine.EventSystems;

public class Wheel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    bool selected;

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

    private void Update()
    {
        
        if (selected)
        {
            //modificar la rotacion de Z dependiendo de la posicion del raton, la vamos a ir sumando anda mas la diferencia
        }
    }

}
