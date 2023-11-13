using UnityEngine;

public class mole_move_pattern : MonoBehaviour {
    // public params
    [SerializeField]
    private Vector2 area;
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float out_mark;
    [SerializeField]
    private float duration;
    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private GameObject excl;
    // private
    private float timer;

    private enum state {
        hide,
        outside,
    }
    private Vector3 velocity, target_position = Vector3.zero;
    private GameObject up_position, hide_position;
    private state mole_state;
    private Vector3 box_center;
    private SpriteRenderer HeadSprite;
    private bool activated = false;

    private void Awake() {
        box_center = transform.position;
        target_position = transform.position;
        HeadSprite = head.GetComponent<SpriteRenderer>();

        up_position = new GameObject("default position");
        up_position.transform.position = head.transform.position;
        up_position.transform.parent = gameObject.transform;

        hide_position = new GameObject("hide position");
        hide_position.transform.position = head.transform.position - new Vector3(0, 4, 0);
        hide_position.transform.parent = gameObject.transform;
    }
    private void FixedUpdate() {
        timer += Time.fixedDeltaTime;
        mole_state = change_state(timer);
        if (timer >= duration)
            timer = 0;
        // update target target position
        if (check_bounce_in_area(area)) {
            target_position = Handlers.main.BounceMov.transform.position;
        }
        // Update look at
        look_to();
        // move_pattern
        if (mole_state == state.hide) {
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(target_position.x, transform.position.y, transform.position.z),
                Time.fixedDeltaTime * speed);
        }
        // hide or show up
        if (mole_state == state.hide) {
            head.transform.position = Vector3.Lerp(
                head.transform.position, hide_position.transform.position, Time.deltaTime * 3);
            activated = false;
        } else {
            head.transform.position = Vector3.Lerp(
                head.transform.position, up_position.transform.position, Time.deltaTime * 3);
            if (!activated && head.activeInHierarchy) {
                activated = true;
                Instantiate(excl, (up_position.transform.position + Vector3.up * 1.5f),
                            Quaternion.identity);
            }
        }
    }
    private state change_state(float timer) {
        if (this.timer >= out_mark)
            return state.outside;
        else {
            return state.hide;
        }
    }
    private bool check_bounce_in_area(Vector2 size) {
        return Physics2D.BoxCast(box_center, size, 0, Vector2.zero, 0, layer);
    }
    void OnDrawGizmos() {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, area);
    }
    private void look_to() {
        HeadSprite.flipX =
            (Mathf.Sign(Handlers.main.BounceMov.transform.position.x - transform.position.x) > 0);
    }
}
