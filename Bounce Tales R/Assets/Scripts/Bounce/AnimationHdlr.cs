using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AnimationHdlr : MonoBehaviour {
    private float input;
    private bool inputjump;
    private bool AnimState = false;
    private float timer;
    [HideInInspector]
    public float t;
    public bool changing = false;
    private int target = 7;
    private Animator AnimHdlr;
    [Range(0, 20)]
    [SerializeField]
    private float IddlePoint;
    private CinemachineVirtualCamera VC;
    private bool done = false;
    private bool done_d = false;
    private void Awake() {
        AnimHdlr = transform.GetComponent<Animator>();
    }
    private void Start() {
        VC = Handlers.main.virtualCamera.GetComponent<CinemachineVirtualCamera>();
    }
    private void FixedUpdate() {
        input = Input.GetAxisRaw("Horizontal");
        inputjump = Input.GetButton("Jump");
        timer += Time.fixedDeltaTime;
        t += Mathf.Clamp(Time.fixedDeltaTime, -5, 2);

        // check if we're moving
        if (Mathf.Abs(input) > .2f || inputjump == true) {
            if (!done_d) {
                t = 0;
                done_d = true;
            }
            timer = 0;
            AnimState = false;
            if (!changing)
                target = 7;
            done = false;
        }
        if (timer > IddlePoint) {
            if (!done) {
                t = 0;
                done = true;
            }
            done_d = false;
            AnimState = true;
            if (!changing)
                target = 5;
        }
        ApplyAnimState(AnimState);
        if (!changing)
            fixCamera(t, target, 5);
    }
    private void ApplyAnimState(bool x) {
        AnimHdlr.SetBool("iddle", x);
    }
    public void fixCamera(float t, int target, float d) {
        VC.m_Lens.OrthographicSize = Mathf.Lerp(VC.m_Lens.OrthographicSize, target, t / d);
    }
}
