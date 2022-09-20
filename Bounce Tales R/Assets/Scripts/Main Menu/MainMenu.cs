using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit ()
    {
        Application.Quit();
    }

//El enlace posiblemente se modificará pronto.
    public void MoreGames()
    {
        Application.OpenURL("https://bounceteam.org");
    }
}
