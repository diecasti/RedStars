using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textmove : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 25;
    }
}
