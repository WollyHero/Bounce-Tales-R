using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDestroyImplementation : MonoBehaviour
{
    [SerializeField] private GameObject[] Particles;
    [SerializeField] private GameObject[] Send;
    [SerializeField] private Collider2D[] ColSend;
    [SerializeField] private DestroyEvent DE;
    [SerializeField] private float ForcePush;
    //this is a generic implementation to destroy an object based on the DestroyEvent.
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Bounce"))
        {
            Handlers.main.BounceMov.rb.AddForce(Vector2.up * ForcePush * Time.deltaTime, ForceMode2D.Impulse);
            DE.DestroyEnh(Send, ColSend, Particles);
        }
    }
}
