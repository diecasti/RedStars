using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator a = cambiarEscena();
        StartCoroutine(a);
    }

    IEnumerator cambiarEscena()
    {
        yield return new WaitForSeconds(60.0f * 8); //8 minutitos es suficiente para un play tan aburrido como este
        StopAllCoroutines(); //se acabo
        SceneManager.LoadScene("End");
    }
}
