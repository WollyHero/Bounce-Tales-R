using System.Collections;
using UnityEngine;

public class ColorFlicker : MonoBehaviour {
    public Color skyColor;
    public Color plantsColor;
    public float flickerDuration = 3f;
    public int flickerCount = 9;
    public SpriteRenderer yourPlantsSpriteRenderer;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bounce")) {
            StartCoroutine(FlickerColors());
        }
    }

    IEnumerator FlickerColors() {
        Color originalSkyColor = Camera.main.backgroundColor;
        Color originalPlantsColor = yourPlantsSpriteRenderer.color;

        for (int i = 0; i < flickerCount; i++) {
            Camera.main.backgroundColor = skyColor;
            yourPlantsSpriteRenderer.color = plantsColor;
            yield return new WaitForSeconds(flickerDuration / (flickerCount * 2));

            Camera.main.backgroundColor = originalSkyColor;
            yourPlantsSpriteRenderer.color = originalPlantsColor;
            yield return new WaitForSeconds(flickerDuration / (flickerCount * 2));
        }

        Camera.main.backgroundColor = skyColor;
        yourPlantsSpriteRenderer.color = plantsColor;
    }
}
