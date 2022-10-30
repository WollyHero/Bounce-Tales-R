using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {
    public void PlayGame ()
	
	//Main Menu button functions
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit ()
    {
        Application.Quit();
    }

    public void MoreGames()
    {
        Application.OpenURL("https://bounceteam.org");
    }
	
}
