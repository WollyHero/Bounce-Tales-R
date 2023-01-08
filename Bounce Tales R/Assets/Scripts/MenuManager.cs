using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Los GameObjects que se activarán cuando el jugador vuelva al menú principal.
    public GameObject[] objectsToActivate;

    // Se llama cuando se carga una escena.
    private void OnLevelWasLoaded(int level)
    {
        // Verifica si se ha cargado la escena del menú principal.
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Activa los GameObjects.
            foreach (GameObject go in objectsToActivate)
            {
                go.SetActive(true);
            }
        }
    }
}
