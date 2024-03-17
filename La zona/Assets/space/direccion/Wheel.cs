
using UnityEngine;
using UnityEngine.EventSystems;

public class Wheel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    bool selected;
    Vector2 lastMouse;
    public int valor;
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
        lastMouse = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;
    }


    bool IsLeft(Vector2 A, Vector2 B) { return (-A.x * B.y + A.y * B.x < 0); }
    float HowManyLeft(Vector2 A, Vector2 B) { return (-A.x * B.y + A.y * B.x); }


    private void Update()
    {
        
        if (selected)
        {

            //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector3 direction = mousePosition - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //transform.localRotation *= Quaternion.AngleAxis(angle, Vector3.up);


            //modificar la rotacion de Z dependiendo de la posicion del raton, la vamos a ir sumando anda mas la diferencia
            Vector2 mousePos = Input.mousePosition;
           
            Vector2 centro = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            //calculando la diferencia entre el punto anterior y el actual, ver hacia que lugar hay que darle inercia
            Vector2 delta = (mousePos - centro);
            Vector2 ori = (lastMouse - centro);

            Vector3 cross = Vector3.Cross(delta, ori);




            if (cross == Vector3.zero)
            {
                // Target is straight ahead
            }
            else if (!IsLeft(delta, ori))
            {


                float multiplyFactor = Mathf.Abs(HowManyLeft(delta, ori));
                multiplyFactor = multiplyFactor / 100.0f;
                if (multiplyFactor > 10)
                    multiplyFactor = 3;

                // Target is to the right
                //Debug.Log(cross.y);

                transform.localRotation *= Quaternion.AngleAxis(-1 * multiplyFactor, Vector3.up);
                valor += (-1);//* (int)multiplyFactor);
            }
            else
            {

                float multiplyFactor = Mathf.Abs(HowManyLeft(delta, ori));
                multiplyFactor = multiplyFactor / 100.0f;
                if (multiplyFactor > 10)
                    multiplyFactor = 3;
                //Debug.Log("izquierda");
                // Target is to the left
                transform.localRotation *= Quaternion.AngleAxis(1 * multiplyFactor, Vector3.up);
                valor += (1); //* (int)multiplyFactor);
            }

            valor = Mathf.Clamp(valor, 0, 1000);
            lastMouse = mousePos;
        }
    }

}
