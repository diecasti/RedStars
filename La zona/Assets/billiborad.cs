using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billiborad : MonoBehaviour
{

    void Update()
    {
        transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);
    }
}
