using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float diveForce = 10f; // Adjust this value for desired dive force
    public float groundedForceMultiplier = 0.5f; // Adjust this value for reduced force when not grounded
    public int maxJumpCount = 3;
    private int currentJumpCount = 0;
    private bool isGrounded = false;
    private bool canDive = true;
    private bool canDash = true;
    private JumpCounterUI jumpCounterUI; // Reference to the JumpCounterUI script
    private DashCounterUI dashCounterUI; // Reference to the DashCounterUI script

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCounterUI = FindObjectOfType<JumpCounterUI>(); // Find the JumpCounterUI component in the scene
        jumpCounterUI.IncreaseJump(maxJumpCount); // Set the initial jump count
        dashCounterUI = FindObjectOfType<DashCounterUI>(); // Find the DashCounterUI component in the scene
        dashCounterUI.SetDashes(1); // Set the initial dash count
    }

    private void Update()
    {
        // Horizontal Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(moveInput * movementSpeed, 0f));

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && currentJumpCount < maxJumpCount)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            currentJumpCount++;
            jumpCounterUI.DecreaseJump(); // Decrease jump count
        }

        // Dashing
        if (Input.GetKeyDown(KeyCode.S) && !isGrounded && canDive && canDash)
        {
            rb.velocity = new Vector2(rb.velocity.x, -diveForce);
            canDive = false;
            canDash = false;
            dashCounterUI.DecreaseDash(); // Decrease dash count
        }

        // Grounded Check
        if (isGrounded)
        {
            if (currentJumpCount == maxJumpCount)
            {
                currentJumpCount = 0;
                jumpCounterUI.IncreaseJump(maxJumpCount); // Reset jump count
            }
            canDive = true;
            dashCounterUI.ResetDash(); // Reset dash count
            canDash = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is no longer grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Apply reduced force when not grounded
        if (!isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x * groundedForceMultiplier, 0f));
        }
    }
}
