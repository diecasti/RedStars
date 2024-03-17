using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool paused = false;
    public GameObject game;
    public GameObject puseCanvas;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                PauseGame();
            }
            else
            {
                paused = false;
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
        game.SetActive(false);
        puseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    void ResumeGame()
    {

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        game.SetActive(true);
        puseCanvas.SetActive(false);
    }

}
