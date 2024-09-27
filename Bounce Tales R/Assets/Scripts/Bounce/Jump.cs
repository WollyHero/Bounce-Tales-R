using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private Params cfg;
    [SerializeField]
    private float JumpHeight;
    [SerializeField]
    private float RatioCancel;

    private float TimeButtonIsPressed;
    private Rigidbody2D rb;
    private bool jumpCancel = false;
    private bool isJumping = false; 
    private bool jumpHeld = false;  

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        if (Input.GetButton("Jump"))
        {
            TimeButtonIsPressed += Time.deltaTime;
            jumpHeld = true; 
        }

        if (IsGrounded())
        {  
            rb.gravityScale = 1;
            jumpCancel = false;
            isJumping = false; 

            if (jumpHeld)
            {
                JumpAction();
            }
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpAction();
        }

        if (Input.GetButtonUp("Jump") || TimeButtonIsPressed > 1f)
        {
            TimeButtonIsPressed = 0; 
            jumpCancel = true;
            jumpHeld = false; 
        }
    }

    private void FixedUpdate()
    {
        if (jumpCancel)
        {  
            rb.AddForce(new Vector2(0, RatioCancel));
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position - cfg.col[0], new Vector3(1, .4f, 1), 0,
                     Vector3.zero, 0, cfg.Mask);
    }

    private float JumpFormula(float Height)
    {
        return Mathf.Sqrt(-2.0f * Physics2D.gravity.y * Height);
    }

    private void JumpAction()
    {
        if (!isJumping)
        {  
            rb.AddForce(new Vector2(0, JumpFormula(JumpHeight)), ForceMode2D.Impulse);
            isJumping = true;
        }
    }
}


