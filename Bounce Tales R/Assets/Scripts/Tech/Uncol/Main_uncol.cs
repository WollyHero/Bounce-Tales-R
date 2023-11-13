using Cinemachine;
using UnityEngine;

public class Main_uncol : MonoBehaviour {
    [SerializeField]
    private Material ReverseMaterial;
    private Vector3 NewCol;
    private Vector4 ColState;
    private GameObject obj_r;
    [SerializeField]
    private float Speed;
    private Collider2D colref;
    private void Awake() {
        obj_r = new GameObject("dif");
        colref = transform.GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Bounce")) {
            NewCol = new Vector3(1, 1, 1);
            // for camera movement
            obj_r.transform.position = (Handlers.main.BounceMov.transform.position +
                                        transform.position + new Vector3(0, 0, 2)) /
                                       2;
            Handlers.main.virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow =
                obj_r.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Bounce")) {
            NewCol = new Vector3(0, 0, 0);
            Handlers.main.virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow =
                Handlers.main.BounceMov.transform;
        }
    }

    private void FixedUpdate() {
        ColState = ReverseMaterial.GetVector("_Reverse");
        if (colref == null) {
            NewCol = new Vector3(0, 0, 0);
        }
        ReverseMaterial.SetVector(
            "_Reverse", new Vector4(test(ColState.x, NewCol.x), test(ColState.y, NewCol.y),
                                    test(ColState.z, NewCol.z), 0));
    }
    private float test(float a, float b) {
        return Mathf.Lerp(a, b, Time.deltaTime * Speed);
    }
}
