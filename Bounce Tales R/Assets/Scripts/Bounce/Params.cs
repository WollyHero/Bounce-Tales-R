using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Params/NewData")]
public class Params : ScriptableObject
{
    [Header("General // Opts")]
    public Vector3[] col;

    [Header("Jump // Opts")]
    public float JumpForce;

    [Range(0, 1)]
    public float MaxTimeJump;
    public LayerMask Mask;

    [Header("Movement // opts")]
    public float ForceVel;
    public float density;
    public float linearDrag;

    private void OnEnable()
    {
        col[0] = new Vector3(0, .61f, 0);
        JumpForce = .89f;
        MaxTimeJump = .26f;
        Mask = LayerMask.GetMask("Ground");
        ForceVel = 13;
        density = 0.4f;
        linearDrag = 2;
    }
}
