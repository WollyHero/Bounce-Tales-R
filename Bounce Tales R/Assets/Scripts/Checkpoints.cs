using UnityEngine;

public class Checkpoints : MonoBehaviour {
    [Tooltip("the # of the checkpoint, a lower number means a early checkpoint")]
    public int checkpointId = 1;
    private void OnTriggerEnter2D(Collider2D entry) {
        if (entry.CompareTag("Bounce")) {
            if (checkpointId > Handlers.main.checkpoint) {
                print("reached checkpoint: " + checkpointId);
                Handlers.main.checkpoint = checkpointId;
            }
        }
    }
}
