using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBounce : MonoBehaviour
{
	[SerializeField]private Transform Bounce;
	private void Update() {
		print(GetPushDir());
	}
	private Vector3 GetPushDir(){
		Vector3 PushDir = (transform.position - Bounce.position);
		return PushDir;
	}
}
