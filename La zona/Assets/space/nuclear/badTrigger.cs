using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        barraNuclear a = other.GetComponent<barraNuclear>();
        if (a)
        { 
           a.spawnBarra();
        }
    }
}
