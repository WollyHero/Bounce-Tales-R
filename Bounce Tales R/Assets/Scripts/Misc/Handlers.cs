using UnityEngine;
using Cinemachine;
using System.Collections.Generic;

public class Handlers : MonoBehaviour {
    public static Handlers main;
    [HideInInspector]
    public Params PublicParams;
    [HideInInspector]
    public List<int> id_to_unload = new List<int>();

    public GameObject virtualCamera;
    public int EggsCount = 0;
    public float TimeElapsed = 0;
    public int checkpoint = 0;
    public Movement BounceMov;
    public Respawn respawnScript;
    public string savefile_name;
    private List<Checkpoints> childs = new List<Checkpoints>();
    private bool HasMove;
    private float x_position;  // just for mesuring when has move

    private void Awake() {
#region Singleton
        // log if there ins an instance of Handlers
        if (Handlers.main == null) {
            main = this;
        } else {
            Debug.LogError("There is already an instance for Handles " + Handlers.main.gameObject +
                           " Make sure you dont make more than 1 instance of Handlers script.");
            Debug.LogError("Overload : " + this);
        }
        // log if Bounce == null
        if (BounceMov == null) {
            Debug.LogError("There is no Bounce Mov in : " + BounceMov +
                           " Parametter, Fill it in order to fix potencial errors.");
        }
#endregion
        respawnScript = transform.GetComponent<Respawn>();
        GetCheckpoints("Checkpoint", childs);
        // TODO: THIS IS TESTING
        Debug.LogWarning("YOU ARE LOADING CONSTANTLY A TEST FILE, BEWARE!");
        MustLoad();
        Unlaod();
    }
    private void Start() {
        virtualCamera = GameObject.FindWithTag("Camera");
    }

    private void Update() {
        if (!HasMove) {
            x_position += Input.GetAxisRaw("Horizontal");
            if (x_position >= .3f) {
                HasMove = true;
            }
        }
        // if Has move then Start the timer.
        if (HasMove) {
            TimeElapsed += Time.deltaTime;
        }
    }
    // TODO: get the checkpoint respawn
    private void GetCheckpoints(string tag, List<Checkpoints> list) {
        foreach (GameObject child in GameObject.FindGameObjectsWithTag(tag)) {
            list.Add(child.GetComponent<Checkpoints>());
        }
    }
    public void Unlaod() {
        ID_HOLDER[] objs = FindObjectsOfType<ID_HOLDER>();
        foreach (ID_HOLDER f_obj in objs) {
            foreach (int d_id in id_to_unload) {
                if (f_obj.id == d_id) {
                    Destroy(f_obj.gameObject);
                }
            }
        }
    }
    public void MustLoad() {
        SaveClass temp_L = new SaveClass(0, 0, 0, new List<int>());
        temp_L.CreateBaseDirectory();
        temp_L = temp_L.ParseToClass(savefile_name);
        // Load the neccesary things.
        id_to_unload = temp_L.Unload_obj;
    }
    public Vector2 GetRespawn() {
        Vector2 RespawnPos = new Vector2(0, 0);
        foreach (Checkpoints RScript in childs) {
            if (RScript.checkpointId == this.checkpoint) {
                RespawnPos = RScript.transform.position;
                print("checkpoint founded, the ResPoint will be: " + RespawnPos);
            }
        }
        // just for extra validation
        if (RespawnPos == Vector2.zero) {
            Debug.LogWarning(
                "The Respawn point is Vecotor 0, be sure that you've set up all correctly in checkpoints ;)");
        }
        return RespawnPos;
    }
}
