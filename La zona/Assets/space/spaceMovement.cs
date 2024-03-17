using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMovement : MonoBehaviour
{
   public Camera cam;
    public float aceleracion = 1;
    Vector3 velocidad;
    public float sensitivity = 15;


    minijuego currentmigame;

    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;


    public bool focused = false;
    public bool lockView = false;

    public GameObject mano;
    public GameObject manoBoton;

    public Texture2D cursorTexture;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
        Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
        Cursor.SetCursor(cursorTexture, new Vector2(16,16), CursorMode.Auto);


    }

    private void Update()
    {

        //rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        ////rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);


        velocidad = 0.5f * velocidad;
        if (!focused)
        {
            if (Input.GetKey(KeyCode.W))
            {
                velocidad += transform.forward * aceleracion;
            }
            if (Input.GetKey(KeyCode.S))
            {
                velocidad -= transform.forward * aceleracion;
            }
            if (Input.GetKey(KeyCode.A))
            {
                velocidad -= transform.right * aceleracion;
            }
            if (Input.GetKey(KeyCode.D))
            {
                velocidad += transform.right * aceleracion;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                velocidad += transform.up * aceleracion;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocidad -= transform.up * aceleracion;
            }
            //que al velocidad no sea mayor de 3
            if (velocidad.magnitude > 3)
            {
                velocidad = velocidad.normalized * 3;
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //transform.RotateAroundLocal(transform.forward, 1 * sensitivity);
            transform.localRotation *= Quaternion.AngleAxis(sensitivity * 50 * Time.deltaTime, Vector3.forward);
        }
        if (Input.GetKey(KeyCode.E))
        {
            //transform.RotateAroundLocal(transform.forward, -1 * sensitivity);
            transform.localRotation *= Quaternion.AngleAxis(sensitivity * -50 * Time.deltaTime, Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!focused)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.forward, out hit, 5.0f))
                {

                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                    if (hit.transform.GetComponent<minijuego>()){
                        goToMinigame(hit.transform.GetComponent<minijuego>());
                        hit.transform.GetComponent<BoxCollider>().enabled = false;
                        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
                    }
                    else if (hit.transform.GetComponent<Buttom>())
                    {

                        mano.SetActive(false);
                        manoBoton.SetActive(true);

                        IEnumerator rutina = Desbotonar();
                        StartCoroutine(rutina);

                        hit.transform.GetComponent<Buttom>().UseButtom();
                    }
                }
            }
            else
            {
                focused = false;
                currentmigame.transform.GetComponent<BoxCollider>().enabled = true;
                currentmigame.selected = false;
                lockView = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }


    public IEnumerator Desbotonar()
    {
      
        yield return new WaitForSeconds(0.5f);

        mano.SetActive(true);
        manoBoton.SetActive(false);

        yield return null;
    }


    void goToMinigame(minijuego juego)
    {
        //move player to the game, instanly

        transform.position = juego.playpoint.position;
        transform.rotation = juego.playpoint.rotation;
        juego.selected = true;
        focused = true;
        currentmigame = juego;
        if (juego.lookView)
            lockView = true;
        //TODO enable cursor
    }


    private void FixedUpdate()
    {
        transform.position += velocidad * Time.deltaTime;

        //velocidad = 0.2f * velocidad;

        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        //transform.RotateAroundLocal(transform.up, rotateHorizontal * sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        //transform.RotateAroundLocal(transform.right, -rotateVertical * sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player

        if (!lockView)
        {
            transform.localRotation *= Quaternion.AngleAxis(sensitivity * rotateHorizontal, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(sensitivity * -rotateVertical, Vector3.right);
        }

    }
}
