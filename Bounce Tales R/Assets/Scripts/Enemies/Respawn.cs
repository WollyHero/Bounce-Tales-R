using UnityEngine;
using Cinemachine;
public class Respawn : MonoBehaviour {
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    private Vector3 Position;
    private bool Invoked = false;
    private float timer = 0;
    [SerializeField]
    private float animduration = 5;

    public void InvokeRespawn(Vector3 position) {
        Invoked = true;
        this.Position = position;
        vcam.Follow = null;
        Handlers.main.BounceMov.gameObject.SetActive(false);
        Handlers.main.BounceMov.transform.position = Handlers.main.GetRespawn();
    }
    private void Start() {
        vcam = Handlers.main.virtualCamera.GetComponent<CinemachineVirtualCamera>();
    }
    private void Update() {
        if (Invoked) {
            timer += Time.deltaTime;
        }

        if (timer >= animduration) {
            vcam.Follow = Handlers.main.BounceMov.transform;
            Invoked = false;
            timer = 0;
            Handlers.main.BounceMov.gameObject.SetActive(true);
        }
    }
}
