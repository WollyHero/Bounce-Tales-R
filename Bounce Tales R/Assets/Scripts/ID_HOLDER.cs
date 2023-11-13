using UnityEngine;

public class ID_HOLDER : MonoBehaviour {
    private bool hasCollide = false;
    public int id;
    private void OnTriggerEnter2D(Collider2D collision) {
        // just send the id to the list of unlaod one.
        // very simple stuff.
        if (!hasCollide) {  // just in case xD
            Handlers.main.id_to_unload.Add(id);
            hasCollide = true;
        }
    }
}
