using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class barraNuclear : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public bool selected;
    Vector3 mousePosition;
    public Transform player;
    private Vector3 initial;


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
        mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;
    }

    private void Update()
    {
        if (selected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            transform.rotation = player.rotation;
        }
    }

    public void spawnBarra()
    {
        transform.position = initial;
        transform.rotation = Random.rotation;
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        selected = false;
    }


    private void Start()
    {
        initial = transform.position;
        spawnBarra();
    }
}
