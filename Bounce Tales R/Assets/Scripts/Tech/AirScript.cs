using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirScript : MonoBehaviour
{
    [Range(0, 50)][SerializeField] private float Force;
    [SerializeField] private Vector2 dir;
    private Rigidbody2D rb;
    private void OnTriggerStay2D(Collider2D entry)
    {
        if (entry.CompareTag("Bounce"))
        {
            if (rb == null)
            {
                rb = entry.gameObject.transform.GetComponent<Rigidbody2D>();
            }
            rb.AddForce(new Vector2(dir.x * Force * Time.deltaTime, dir.y * Force * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
}
