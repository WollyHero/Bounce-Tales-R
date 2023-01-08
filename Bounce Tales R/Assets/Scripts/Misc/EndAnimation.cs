using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAnimation : MonoBehaviour
{
    // La animación que se reproducirá cuando el jugador llegue a la meta final.
    public Animation animation;

    // El sonido que se reproducirá cuando el jugador llegue a la meta final.
    public AudioClip winSound;

    // El componente AudioSource del objeto al que está asociado el script.
    private AudioSource audioSource;

    // Se llama al inicio de la ejecución del script.
    private void Start()
    {
        // Obtiene una referencia al componente AudioSource del objeto al que está asociado el script.
        audioSource = GetComponent<AudioSource>();
    }

    // Se llama cuando el jugador llega a la meta final.
    public void OnReachEnd()
    {
        // Reproduce la animación.
        animation.Play();

        // Reproduce el sonido de victoria.
        audioSource.PlayOneShot(winSound);

        // Espera 6 segundos antes de volver al menú principal.
        StartCoroutine(ReturnToMenuCoroutine());
    }

    // La corrutina que se encarga de volver al menú principal después de 6 segundos.
    private IEnumerator ReturnToMenuCoroutine()
    {
        // Espera 6 segundos.
        yield return new WaitForSeconds(6);

        // Carga el menú principal.
        SceneManager.LoadScene(1);
    }
}
