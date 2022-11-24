using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    [Range(0, 20)]
    private float Offset = 5;
    private float Timer;

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > Offset)
            Destroy(transform.gameObject);
    }
}
