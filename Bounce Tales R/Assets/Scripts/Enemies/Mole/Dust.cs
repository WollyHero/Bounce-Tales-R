using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField]
    private MoleMovementHandler moleMovementHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bounce"))
        {
            moleMovementHandler.LaunchHead();
        }
    }
}