using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
    [Range(0, 30)]
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private GameObject reference;
    private void FixedUpdate() {
        reference.transform.Rotate(new Vector3(0, 0, 40) * speed* Time.fixedDeltaTime);
    }
}
