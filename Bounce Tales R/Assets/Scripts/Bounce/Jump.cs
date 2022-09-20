using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
	[Header("Opts")]
	[Range(0,2)][SerializeField]private float JumpForce;
	[Range(0,1)][SerializeField]private float MaxTimeJump;
	[SerializeField]private LayerMask Mask;
	#region PrivateStuff
	private Rigidbody2D rb;
	private bool CanJump;
	private float TimeElapsed = 0; 
	#endregion

	private void Awake() {
		rb = transform.GetComponent<Rigidbody2D>();
	}

	private void Update() {
		/*
		 * anytime we're on the ground the var: CanJump will be = true.
		 * */
		if(IsGrounded())
			CanJump = true;
		//update the TimeElapsed Var.
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
		/* anytime we're pressing the jump button & CanJump = true, which means that we're able to jump, then start a timer
		 * if we stop pressing the button Jump then the timer will = to 0 and the var CanJump = false to prevent starting the timer before we're on the ground.*/ 
		if(JumpBtt() && CanJump){
			TimeElapsed += Time.deltaTime;
			if(TimeElapsed >= MaxTimeJump){
				TimeElapsed = 0;
				CanJump = false;
			}}
		else{
			TimeElapsed = 0;
			if(!IsGrounded())
			CanJump = false;
		}
	}
	private bool JumpBtt(){
		return Input.GetButton("Jump");
	}
	//will draw a Gizmos for the JumpColider
	private void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position - new Vector3(0,.35f,0), new Vector3(1f,.4f,1));
	}
}
