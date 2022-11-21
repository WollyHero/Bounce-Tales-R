using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMovementHandler : MonoBehaviour
{
    [SerializeField]
    private Braidel Mov;
    private float timer;

    //timer Opts
    [SerializeField]
    [Range(0, 10)]
    private float MaxDuration,
        PointOfRealease;

    [SerializeField]
    private GameObject MolesHead;

    [SerializeField]
    private Vector3 Pos;
    private SpriteRenderer SpriteMole;

    [SerializeField]
    private Animator DustAnim;

    private void Awake()
    {
        SpriteMole = MolesHead.transform.GetComponent<SpriteRenderer>();
        Pos = MolesHead.transform.localPosition + Pos;
    }

    private void Update()
    {
        StateHandler();
    }

    private void StateHandler()
    {
        timer += Time.deltaTime;
        if (timer > PointOfRealease)
        {
            SpriteMole.flipX = LookTo();
            Mov.enabled = false;
            MoveHead(Pos);
            DustAnim.enabled = false;
        }
        else
        {
            DustAnim.enabled = true;
            MoveHead(new Vector2(Pos.x, Pos.y * -1 * 4));
        }
        if (timer > MaxDuration)
        {
            timer = 0;
            Mov.enabled = true;
        }
    }

    private void MoveHead(Vector2 FinalPos)
    {
        MolesHead.transform.localPosition = Vector2.Lerp(
            MolesHead.transform.localPosition,
            (FinalPos),
            Time.deltaTime * 3
        );
    }

    private bool LookTo()
    {
        if (MolesHead.transform.position.x - Handlers.main.BounceMov.transform.position.x > .3f)
        {
            return false;
        }
        return true;
    }
}
