using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class Emisor : MonoBehaviour {
    [Header("Params")]
    [SerializeField]
    private Vector3[] Dirs;
    [SerializeField]
    private GameObject[] Doors;
    [SerializeField]
    private Transform CamPos;
    [SerializeField]
    private CinemachineVirtualCamera Vcam;
    [SerializeField]
    private float TimeToMoveTheCamera;
    [SerializeField]
    private Animator leverAnimator;
    // private
    private bool HasActive = false;
    private Movement MovBounce;
    private Jump JumpScriptFromBounce;
    private bool PreventClosing = true;
    private SpriteRenderer SpriteHdrl;
    private List<Vector3> FixedDir = new List<Vector3>();
    private float timer;
    private GameObject BounceGameObj;

    private void Awake() {
        SpriteHdrl = transform.GetComponent<SpriteRenderer>();
        BounceGameObj = Vcam.Follow.gameObject;
        MovBounce = BounceGameObj.transform.GetComponent<Movement>();
        JumpScriptFromBounce = BounceGameObj.transform.GetComponent<Jump>();
        leverAnimator = transform.parent.GetComponent<Animator>();
    }
    private void Start() {
        try {
            for (int i = 0; i < Dirs.Length; i++) {
                FixedDir.Add(Doors[i].transform.position + Dirs[i]);
            }
        } catch {
            Debug.Log("Error, make sure you put a door in " + this.transform + " before testing");
        }
    }
    private void Update() {
        if (HasActive && PreventClosing) {
            timer += Time.deltaTime;
            BounceMovActive(false);
            if (timer >= TimeToMoveTheCamera) {
                Vcam.Follow = CamPos;
                for (int i = 0; i < Doors.Length; i++) {
                    Doors[i].transform.position =
                        Vector3.Lerp(Doors[i].transform.position, FixedDir[i], Time.deltaTime);
                }
            }
            if (timer >= 5) {
                BounceMovActive(true);
                Vcam.Follow = BounceGameObj.transform;
                PreventClosing = false;
            }
        }
    }
    private void ApplySprite(Sprite Active, Sprite Inert) {
        if (HasActive) {
            SpriteHdrl.sprite = Active;
        } else {
            SpriteHdrl.sprite = Inert;
        }
    }
    private void BounceMovActive(bool x) {
        if (MovBounce != null && JumpScriptFromBounce != null) {
            MovBounce.enabled = x;
            JumpScriptFromBounce.enabled = x;
            Handlers.main.BounceMov.rb.AddForce((Handlers.main.BounceMov.rb.velocity / 2) * -1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bounce")) {
            leverAnimator.SetBool("Activated", true);
            HasActive = true;
        }
    }
}
