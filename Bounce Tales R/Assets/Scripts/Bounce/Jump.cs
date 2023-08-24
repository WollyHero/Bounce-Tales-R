using UnityEngine;

public class Jump : MonoBehaviour {
	[SerializeField]
	private Params cfg;
	[SerializeField]
	private float JumpHeight;
	[SerializeField]
	private float RatioCancel;

	private float TimeButtonIsPressed;
	private Rigidbody2D rb;
	private bool jumpCancel = false;

	private void Awake() {
		// TODO: make a singleton for this shit
		rb = transform.GetComponent<Rigidbody2D>();
	}
	private void Update() {
		if (Input.GetButton("Jump"))
			TimeButtonIsPressed += Time.deltaTime;

		if (IsGrounded()) {  // just reset evrything to their normal state>
			rb.gravityScale = 1;
			jumpCancel = false;
		}
		if (Input.GetButtonDown("Jump")) {
			rb.AddForce(new Vector2(0, JumpFormula(JumpHeight)), ForceMode2D.Impulse);
		}
		if (Input.GetButtonUp("Jump") || TimeButtonIsPressed > 1f) {
			TimeButtonIsPressed = 0;  // reset the timer to avoid bugs.
			jumpCancel = true;
		}
	}
	private void FixedUpdate() {
		if (jumpCancel) {  // Gradually apply force whenever you cancel the jump.
			rb.AddForce(new Vector2(0, RatioCancel));
		}
	}
	/*
	 * Output -> Bool: is box raycast colliding with any object with a certain mask (TODO: get
	 * rid of the fucking cfg variable :rage:
	 */
	private bool IsGrounded() {
		return Physics2D.BoxCast(transform.position - cfg.col[0], new Vector3(1, .4f, 1), 0,
					 Vector3.zero, 0, cfg.Mask);
	}

	/*
	 * Input -> Float: Height (Desired Height to achive)
	 * Output -> Float: Force needed to achive Height
	 */
	private float JumpFormula(float Height) {
		return Mathf.Sqrt(-2.0f * Physics2D.gravity.y * Height);
	}
}
