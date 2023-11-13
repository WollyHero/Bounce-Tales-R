using UnityEngine;

public class niceanimexcl : MonoBehaviour {
    private float timer = 0f;
    private Renderer r;
    private void Start() {
        r = transform.GetComponent<Renderer>();
    }
    private void FixedUpdate() {
        timer += Mathf.Clamp(Time.fixedDeltaTime, 0, 3);

        transform.position += Vector3.up * Time.deltaTime;
        r.material.color = Color.Lerp(r.material.color, new Color(1f, 1f, 1f, 0f), timer / 3);
    }
}
