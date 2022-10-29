using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_uncol : MonoBehaviour
{
    [SerializeField] private Material ReverseMaterial;
    private Vector3 NewCol;
    private Vector4 ColState;
    [SerializeField] private float Speed;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bounce"))
            NewCol = new Vector3(1, 1, 1);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bounce"))
            NewCol = new Vector3(0, 0, 0);
    }
    private void FixedUpdate()
    {
        ColState = ReverseMaterial.GetVector("_Reverse");
        ReverseMaterial.SetVector("_Reverse", new Vector4(
                    test(ColState.x, NewCol.x),
                    test(ColState.y, NewCol.y),
                    test(ColState.z, NewCol.z),
                    0));
    }
    private float test(float a, float b)
    {
        return Mathf.Lerp(a, b, Time.deltaTime * Speed);
    }

}
