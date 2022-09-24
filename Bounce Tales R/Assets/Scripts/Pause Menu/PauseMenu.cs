using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject dialogMenu;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }       
        }
    }

    
    void Resume ()
    {
        dialogMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        dialogMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
