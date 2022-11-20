using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handlers : MonoBehaviour
{
    public static Handlers main;

    [HideInInspector]
    public int EggsCount;

    [HideInInspector]
    public float TimeElapsed;
    public Movement BounceMov;
    private bool HasMove;

    //just for mesuring when has move
    private float x;

    private void Awake()
    {
        //log if there ins an instance of Handlers
        if (Handlers.main == null)
        {
            main = this;
        }
        else
        {
            Debug.LogError(
                "There is already an instance for Handles "
                    + Handlers.main.gameObject
                    + " Make sure you dont make more than 1 instance of Handlers script."
            );
            Debug.LogError("Overload : " + this);
        }
        //log if Bounce == null
        if (BounceMov == null)
        {
            Debug.LogError(
                "There is no Bounce Mov in : "
                    + BounceMov
                    + " Parametter, Fill it in order to fix potencial errors."
            );
        }
    }

    private void Update()
    {
        if (!HasMove)
        {
            x += Input.GetAxisRaw("Horizontal");
            if (x >= .3f)
            {
                HasMove = true;
            }
        }
        //if Has move then Start the timer.
        if (HasMove)
        {
            TimeElapsed += deltaT();
        }
    }

    private float deltaT()
    {
        return Time.deltaTime;
    }
}
