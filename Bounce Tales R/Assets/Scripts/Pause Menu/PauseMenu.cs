using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMainMenu, RestartChapter, ChapterSelection, WatermarkText, Timer, EggCounter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMainMenu.SetActive(false);
        RestartChapter.SetActive(false);
        ChapterSelection.SetActive(false);
        WatermarkText.SetActive(true);
		Timer.SetActive(true);
		EggCounter.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMainMenu.SetActive(true);
        WatermarkText.SetActive(false);
		Timer.SetActive(false);
		EggCounter.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }
}
