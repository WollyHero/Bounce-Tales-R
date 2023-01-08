using UnityEngine;

public class EndZone : MonoBehaviour
{
    // El script del jugador que se ejecutará cuando el jugador llegue a la zona final.
    public EndAnimation endAnimation;

    // Se llama cuando el jugador entra en contacto con el objeto que tiene este script.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que ha colisionado el jugador es el personaje.
        if (other.CompareTag("Bounce"))
        {
            // Ejecuta el script del jugador para que haga la animación y se vuelva al menú principal.
            endAnimation.OnReachEnd();
        }
    }
}
