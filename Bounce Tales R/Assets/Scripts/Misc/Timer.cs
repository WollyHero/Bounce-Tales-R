using System.Collections;
using UnityEngine;
using TMPro; // Importa la librería de TextMesh Pro.

public class Timer : MonoBehaviour
{
    // El elemento de UI que mostrará el tiempo transcurrido.
    public TextMeshProUGUI timerText;

    // La cantidad de minutos que han transcurrido.
    private int minutes = 0;

    // La cantidad de segundos que han transcurrido.
    private int seconds = 0;

    // La corrutina que se encarga de actualizar el tiempo transcurrido cada segundo.
    private IEnumerator timerCoroutine;

    // Se llama al inicio de la ejecución del script.
    private void Start()
    {
        // Inicia la corrutina de actualización del tiempo transcurrido.
        timerCoroutine = TimerCoroutine();
        StartCoroutine(timerCoroutine);
    }

    // La corrutina que se encarga de actualizar el tiempo transcurrido cada segundo.
    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            // Incrementa la cantidad de segundos transcurridos.
            seconds++;

            // Verifica si se han transcurrido 60 segundos (1 minuto).
            if (seconds >= 60)
            {
                // Resetea la cantidad de segundos transcurridos y aumenta la cantidad de minutos transcurridos.
                seconds = 0;
                minutes++;
            }

            // Actualiza el texto del cronómetro en la UI.
            timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");

            // Espera 1 segundo antes de volver a actualizar el tiempo transcurrido.
            yield return new WaitForSeconds(1);
        }
    }
}
