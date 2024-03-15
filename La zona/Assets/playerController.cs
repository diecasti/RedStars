using UnityEngine;

public class playerController : MonoBehaviour
{

    public Movimiento movement;
    bool interseccion = false;


    private void Update()
    {
        if (interseccion)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //girar derecha
                movement.girarMundo(true);
                interseccion = false;

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                //girar izquierda
                //tenemos que ahcer que despues del giro, las piezas queden en el centro de la pieza del vagon, o que el giro termine de forma que las piezes queden en el centro

                movement.girarMundo(false);
                interseccion = false;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<interseccion>())
        {
           // Debug.Log("colision enter");
            interseccion = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {


        if (collision.gameObject.GetComponent<interseccion>())
        {
           // Debug.Log("Collision exit");
            interseccion = false;
        }
    }


}
