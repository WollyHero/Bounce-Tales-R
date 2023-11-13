using UnityEngine;
using Cinemachine;

public class CameraJucy : MonoBehaviour {
    private CinemachineVirtualCamera cam;
    private AnimationHdlr hdlr;
    private bool active;
    private float timer;

    [SerializeField]
    private float up_time = 0;
    [SerializeField]
    private float down_time = 0;

    private void FixedUpdate() {
        if (active) {
            timer += Time.fixedDeltaTime;
            if (timer <= up_time)
                hdlr.fixCamera(timer, 10, up_time);
            if (timer <= up_time + down_time)
                hdlr.fixCamera(timer, 7, (up_time + down_time) * 4);
            if (timer >= up_time + down_time) {
                active = false;
                hdlr.changing = false;
            }
        }
    }
    public void back() {
        if (cam == null)
            cam = Handlers.main.virtualCamera.GetComponent<CinemachineVirtualCamera>();
        if (hdlr == null)
            hdlr = Handlers.main.BounceMov.GetComponent<AnimationHdlr>();
        timer = 0;
        hdlr.changing = true;
        active = true;
    }
}
