using UnityEngine;

public class GenericDestroyImplementation : MonoBehaviour {
    [SerializeField]
    [Tooltip("This array of particles will spawn once you touch the collider")]
    private GameObject[] Particles;
    [SerializeField]
    [Tooltip("This array of GameObject will inactivate once you touch the collider")]
    private GameObject[] Send;
    [SerializeField]

    [Tooltip("list of collider you want to turn off once you collide with the collider")]
    private Collider2D[] ColSend;
    [SerializeField]

    [Tooltip("reference to the destroy_event")]
    private DestroyEvent destroy_event;
    [SerializeField]
    private float ForcePush;
    // this is a generic implementation to destroy an object based on the DestroyEvent.
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Bounce")) {
            Handlers.main.BounceMov.rb.AddForce(Vector2.up * ForcePush * Time.deltaTime,
                                                ForceMode2D.Impulse);
            destroy_event.DestroyEnh(Send, ColSend, Particles);
            Handlers.main.virtualCamera.GetComponent<CameraJucy>().back();  // jucy
        }
    }
}
