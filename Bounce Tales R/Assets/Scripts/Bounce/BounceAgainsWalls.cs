using UnityEngine;

public class BounceAgainsWalls : MonoBehaviour {
	private Rigidbody2D rb;	 // TODO: make a singleton for this shit pleaseeeeeeee
	private PhysicsMaterial2D NoBounciness, Bounciness;
	private float tick;
	private Vector2 LastVelocity;

	private void Awake() {
		rb = transform.GetComponent<Rigidbody2D>();
		NoBounciness = PhysicsInitialization(0.05f, 0);
		Bounciness = PhysicsInitialization(0.05f, 1);
	}
	private void Update() {
		tick += Time.deltaTime;
		if (tick >= 0.05) {  // every few frames change phisics
			if (Mathf.Abs(rb.velocity.x) > 10 ||
			    Mathf.Abs(rb.velocity.y) >
				10) {  // Vel > 2 units? Bounciness : NoBounciness;
				rb.sharedMaterial = Bounciness;
			} else {
				rb.sharedMaterial = NoBounciness;
			}
		}
	}
	/*
	 * Input -> (float: Friction, Bounciness) : needed for PhysicsMaterial2D "constructor"
	 *Output -> a new PhysicsMaterial2D
	 */
	private PhysicsMaterial2D PhysicsInitialization(float Friction, float Bounciness) {
		PhysicsMaterial2D newPhysics = new PhysicsMaterial2D();
		newPhysics.bounciness = Bounciness;
		newPhysics.friction = Friction;
		return newPhysics;
	}
}
