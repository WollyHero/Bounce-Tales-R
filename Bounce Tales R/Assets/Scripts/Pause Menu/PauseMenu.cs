using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    //PauseMainMenu es el cuadro de di�logo principal.
    public GameObject PauseMainMenu;

    public GameObject RestartChapter;

    public GameObject ChapterSelection;
	
	public GameObject WatermarkText;

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

    
    public void Resume ()
    {
        PauseMainMenu.SetActive(false);
        RestartChapter.SetActive(false);
        ChapterSelection.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
		WatermarkText.SetActive(true);
    }

    void Pause ()
    {
        PauseMainMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
		WatermarkText.SetActive(false);
    }

    //Esto permite un cambio entre escenas.

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }

}