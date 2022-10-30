using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyStrokes : MonoBehaviour
{
    //space key
    private bool SpaceKey()
    {
        return Input.GetButton("Jump");
    }
    private Image canvas;
    private void Awake()
    {
        canvas = transform.GetComponent<Image>();
    }
    private void Update()
    {
        if (SpaceKey())
        {
            canvas.color = Color.green;
        }
        else
        {
            canvas.color = Color.white;
        }
    }
}

