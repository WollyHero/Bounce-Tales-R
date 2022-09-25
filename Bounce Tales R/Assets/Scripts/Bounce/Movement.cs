using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[SerializeField]private Params Cfg;
	private float axisX;

	private void Awake() {
		rb = transform.GetComponent<Rigidbody2D>();
	}
	private void Update() {
		axisX = Input.GetAxisRaw("Horizontal");
	}
	private void FixedUpdate() {
		Move(GetWishedVel(rb.velocity.x, Cfg.ForceVel), axisX);
	}
	private void Move(float Force, float Axis){
		//make a Vector for the direction 
		Vector2 Dir = (Vector2.right * Axis) * Force;
		//add the force to the rb
		rb.AddForce(Dir);
	}
	private float GetWishedVel(float Cvel, float Vel){
		/*calculate the ideal velocity based from the actual velocity
		 * Cvel stands for "Current Velocity"
		 * */
		float wishedVel = Vel - Mathf.Abs(Cvel);
		return wishedVel;
	}
}
