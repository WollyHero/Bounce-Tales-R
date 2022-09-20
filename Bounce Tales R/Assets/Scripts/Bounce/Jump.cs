using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
	private Rigidbody2D rb;
	[SerializeField]private float JumpForce;
	[SerializeField]private LayerMask Mask;
	private bool CanJump;
	private float TimeElapsed = 0;
	[Range(0,1)][SerializeField]private float MaxTimeJump;

	private void Awake() {
		rb = transform.GetComponent<Rigidbody2D>();
	}
	private void Update() {
		if(IsGrounded())
			CanJump = true;
		GetTimeElapsed();
	}
	private void FixedUpdate() {
		JumpAct(JumpForce);
	}
	private void JumpAct(float force){
		if(JumpBtt() && CanJump && TimeElapsed <= MaxTimeJump){
			rb.AddForce(Vector2.up * force , ForceMode2D.Impulse);
		}
	}
	private bool IsGrounded(){
		return Physics2D.BoxCast(transform.position - new Vector3(0, .35f, 0), new Vector3(1, .4f, 1), 0, Vector3.zero, 0 , Mask);
	}
	private void GetTimeElapsed(){
		if(JumpBtt() && CanJump){
			TimeElapsed += Time.deltaTime;
			if(TimeElapsed >= MaxTimeJump){
				TimeElapsed = 0;
				CanJump = false;
			}
		}
		else{
			TimeElapsed = 0;
			if(!IsGrounded())
			CanJump = false;
		}
	}
	private bool JumpBtt(){
		return Input.GetButton("Jump");
	}

	private void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position - new Vector3(0,.35f,0), new Vector3(1f,.4f,1));
	}
}
