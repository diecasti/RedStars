using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMovement : MonoBehaviour
{
   public Camera cam;
    Vector3 velocidad;
    public float sensitivity;


    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;

    private void Update()
    {

        //rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        ////rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);


        velocidad = 0.2f * velocidad;

        if (Input.GetKey(KeyCode.W))
        {
            velocidad += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocidad -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocidad -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocidad += -transform.right;
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
    }


    private void FixedUpdate()
    {
        transform.position += velocidad * Time.deltaTime;

        //velocidad = 0.2f * velocidad;

        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        //transform.RotateAroundLocal(transform.up, rotateHorizontal * sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        //transform.RotateAroundLocal(transform.right, -rotateVertical * sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player

        transform.localRotation *= Quaternion.AngleAxis(sensitivity * rotateHorizontal, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(sensitivity * -rotateVertical, Vector3.right);

    }
}
