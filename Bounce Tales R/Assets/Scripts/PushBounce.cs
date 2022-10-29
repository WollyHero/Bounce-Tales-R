using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBounce : MonoBehaviour
{
    [Range(0, 20)][SerializeField] private float ForceToPush;
    private void Awake()
    {
    }
    private Vector2 GetPushDir(float force)
    {
        Vector3 PushDir = (Handlers.main.BounceMov.transform.position - (transform.position - new Vector3(0, 3, 0)));
        float x = Mathf.Sign(PushDir.x) * force;
        float y = Mathf.Sign(PushDir.y) * force;
        return new Vector2(x, y);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Handlers.main.BounceMov.rb.AddForce(GetPushDir(ForceToPush), ForceMode2D.Impulse);
    }
}
