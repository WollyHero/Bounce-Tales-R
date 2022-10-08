using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBounce : MonoBehaviour
{
	[SerializeField]private GameObject Bounce;
	[Range(0,20)][SerializeField]private float ForceToPush;
	private Rigidbody2D rb;
	private void Awake() {
		if(Bounce != null){rb = Bounce.transform.GetComponent<Rigidbody2D>();};
	}
	private Vector2 GetPushDir(float force){
		Vector3 PushDir = (Bounce.transform.position - transform.position);
		float x = Mathf.Sign(PushDir.x)* force;
		float y = Mathf.Sign(PushDir.y)* force;
		return new Vector2(x,y);
	}
	private void OnCollisionEnter2D(Collision2D other) {
		rb.AddForce(GetPushDir(ForceToPush), ForceMode2D.Impulse);
	}
}
