using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{

   public GameObject canvasOn;
   public GameObject canvasOff;
  public void quita()
    {
        Application.Quit();
    }

    public void comenzar()
    {
        SceneManager.LoadScene("espace");
    }

    public void Creditos()
    {
        //desabelear el canvas poner el otro
        canvasOff.SetActive(false);
        canvasOn.SetActive(true);

    }
}
