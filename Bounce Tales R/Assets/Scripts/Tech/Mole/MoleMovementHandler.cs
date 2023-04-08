using UnityEngine;

public class MoleMovementHandler : MonoBehaviour
{
    [SerializeField]
    private Braidel Mov;
    [SerializeField]
    private float MaxDuration = 5f;

    [SerializeField]
    private float PointOfRelease = 2.5f;

    [SerializeField]
    private float AggressionThreshold = 1f;

    [SerializeField]
    private float HeadMoveSpeed = 3f;

    [SerializeField]
    private GameObject MolesHead;

    [SerializeField]
    private Vector3 HeadOffset;

    [SerializeField]
    private Animator DustAnimator;

    private float timer;
    private bool isAggressive = false;
    private bool isDustOverlapping = false;
    private bool isHeadLaunched = false;
    private SpriteRenderer moleSprite;

    private void Awake()
    {
        moleSprite = MolesHead.transform.GetComponent<SpriteRenderer>();
        HeadOffset = MolesHead.transform.localPosition + HeadOffset;
    }

    private void Update()
    {
        StateHandler();
    }

    private void StateHandler()
    {
        timer += Time.deltaTime;

        if (isDustOverlapping)
        {
            Mov.enabled = false;
            MoveHead(HeadOffset);
            DustAnimator.enabled = false;
        }
        else if (timer > PointOfRelease)
        {
            moleSprite.flipX = LookTo();
            Mov.enabled = false;
            MoveHead(HeadOffset);
            DustAnimator.enabled = false;
        }
        else
        {
            DustAnimator.enabled = true;

            if (isAggressive)
            {
                MoveHead(new Vector2(HeadOffset.x, HeadOffset.y * -1));
            }
            else
            {
                MoveHead(new Vector2(HeadOffset.x, HeadOffset.y * -4));
            }
        }

        if (timer > MaxDuration)
        {
            timer = 0;
            Mov.enabled = true;
            isAggressive = false;
        }
    }

    private void MoveHead(Vector2 finalPos)
    {
        MolesHead.transform.localPosition = Vector2.Lerp(
            MolesHead.transform.localPosition,
            finalPos,
            Time.deltaTime * HeadMoveSpeed
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bounce"))
        {
            float distance = Mathf.Abs(transform.position.x - collision.transform.position.x);
            if (distance < AggressionThreshold)
            {
                isAggressive = true;
            }
        }
        else if (collision.gameObject.CompareTag("Dust") && !isHeadLaunched)
        {
            isDustOverlapping = true;
            LaunchHead();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dust"))
        {
            isDustOverlapping = false;
        }
    }

    public void LaunchHead()
    {
        if (!isHeadLaunched) // added condition
        {
            isHeadLaunched = true;
            MolesHead.transform.localPosition = new Vector2(
MolesHead.transform.localPosition.x,
MolesHead.transform.localPosition.y + 4f
);

            if (isDustOverlapping)
            {
                Handlers.main.BounceMov.LaunchPlayer(0f);
            }
            else
            {
                Handlers.main.BounceMov.LaunchPlayer(10f);
            }
        }
    }
}