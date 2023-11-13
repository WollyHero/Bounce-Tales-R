using UnityEngine;

public class SpikeScript : MonoBehaviour {
    [SerializeField]
    private GameObject BounceDeath;
    private bool hasCollided = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bounce") && hasCollided == false) {
            hasCollided = true;
            Instantiate(BounceDeath, Handlers.main.BounceMov.transform.position,
                        Quaternion.identity);
            Handlers.main.respawnScript.InvokeRespawn(transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Bounce")) {
            hasCollided = false;
        }
    }
}
