using UnityEngine;
using TMPro; // Importa la librería de TextMesh Pro.

public class EggCounter : MonoBehaviour
{
    // La cantidad máxima de huevos que pueden recogerse.
    public int maxEggs = 30;

    // La cantidad de huevos que el personaje ha recogido.
    private int eggsCollected = 0;

    // El elemento de UI que mostrará la cantidad de huevos recogidos.
    public TextMeshProUGUI eggCounterText;

    // Se llama cuando el personaje colisiona con un huevo.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que se ha colisionado es un huevo.
        if (other.CompareTag("Egg"))
        {
            // Incrementa la cantidad de huevos recogidos.
            eggsCollected++;

            // Actualiza el texto del contador de huevos en la UI.
            eggCounterText.text = eggsCollected + "/" + maxEggs;

            // Verifica si se han recogido todos los huevos.
            if (eggsCollected >= maxEggs)
            {
                // Has recogido todos los huevos. ¡Felicidades!
                Debug.Log("¡Felicidades! Has recogido todos los huevos.");
            }
        }
    }
}
