using UnityEngine;

public class AirScript : MonoBehaviour {
    [Range(0, 50)]
    [SerializeField]
    private float Force;
    [SerializeField]
    private Vector2 dir;
    private void OnTriggerStay2D(Collider2D entry) {
        if (entry.CompareTag("Bounce")) {
            Handlers.main.BounceMov.rb.AddForce(
                new Vector2(dir.x * Force * Time.deltaTime, dir.y * Force * Time.deltaTime),
                ForceMode2D.Impulse);
        }
    }
}
