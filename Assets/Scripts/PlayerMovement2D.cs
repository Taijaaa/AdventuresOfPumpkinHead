using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Jump Feel")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Better jump physics
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // Flip sprite
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}