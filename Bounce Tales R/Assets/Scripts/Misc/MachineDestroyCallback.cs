using UnityEngine;
using Cinemachine;

[System.Serializable]
public class SpriteTuple {
    public SpriteRenderer SpriteRendererReference;
    public Sprite SpriteReference;
}
public class MachineDestroyCallback : MonoBehaviour {
    [SerializeField]
    [Tooltip("This array of particles will spawn once you touch the collider")]
    private GameObject[] Particles;
    [Tooltip("This array of GameObject will inactivate once you touch the collider")]
    public GameObject[] Send;
    [SerializeField]

    [Tooltip("list of collider you want to turn off once you collide with the collider")]
    private Collider2D[] ColSend;
    [SerializeField]

    [Tooltip("reference to the destroy_event")]
    private DestroyEvent destroy_event;
    [SerializeField]
    private float ForcePush;
    [Tooltip(
        "Tuple to remplace sprites, first will be a reference to the sprite renderer and the second one will be a reference to the destroyed one")]
    [SerializeField]
    private SpriteTuple[] Sprites;

    // this is a generic implementation to destroy an object based on the DestroyEvent.
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Bounce")) {
            foreach (SpriteTuple refs in Sprites) {
                refs.SpriteRendererReference.sprite = refs.SpriteReference;
            }
            Handlers.main.BounceMov.rb.AddForce(Vector2.up * ForcePush, ForceMode2D.Impulse);
            destroy_event.DestroyEnh(Send, ColSend, Particles);
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.transform.CompareTag("Bounce")) {
            Handlers.main.virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow =
                Handlers.main.BounceMov.transform;
        }
    }
}
