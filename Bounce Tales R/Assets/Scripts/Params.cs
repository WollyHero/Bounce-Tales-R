using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Params/NewData")]
public class Params : ScriptableObject{
	[Header("General // Opts")]
	public Vector3[] col;
	[Header("Jump // Opts")]
	[Range(0,1)]public float JumpForce;
	[Range(0,1)]public float MaxTimeJump;
	public LayerMask Mask;
	[Header("Movement // opts")]
	public float ForceVel;
}
