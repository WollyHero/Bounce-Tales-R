using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    // Main Menu sections
    public GameObject MainMenu, Continue, HighScores, Instructions, LevelCompleted;

    //Main Menu buttons
    public GameObject MainMenuContinue, MainMenuHighScores, MainMenuInstructions, ContinueBack, HighScoresBack, InstructionsBack, LevelCompletedOk;

    // Main Menu open and close button actions
    public void OpenContinue()
    {
        Continue.SetActive(true);
        MainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ContinueBack);
    }

    public void CloseContinue()
    {
        Continue.SetActive(false);
        MainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(MainMenuContinue);
    }

    public void OpenHighScores()
    {
        HighScores.SetActive(true);
        MainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(HighScoresBack);
    }

    public void CloseHighScores()
    {
        HighScores.SetActive(false);
        MainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(MainMenuHighScores);
    }

    public void OpenInstructions()
    {
        Instructions.SetActive(true);
        MainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(InstructionsBack);
    }

    public void CloseInstructions()
    {
        Instructions.SetActive(false);
        MainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(MainMenuInstructions);
    }

    public void OpenLevelCompleted()
    {
        LevelCompleted.SetActive(true);
        MainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(LevelCompletedOk);
    }

    public void CloseLevelCompleted()
    {
        LevelCompleted.SetActive(false);
        MainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(MainMenuContinue);
    }
}
