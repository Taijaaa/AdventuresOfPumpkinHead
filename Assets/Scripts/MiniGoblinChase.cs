using UnityEngine;

public class MiniGoblinChase : MonoBehaviour
{
    public float moveSpeed = 3f;

    [Header("Edge Detection")]
    public Transform groundCheck;
    public float groundCheckDistance = 0.5f;
    public LayerMask groundLayer;

    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float direction = player.position.x - transform.position.x;

        // Check if there is ground ahead
        bool groundAhead = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        if (!groundAhead)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        if (direction > 0)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            if (spriteRenderer != null) spriteRenderer.flipX = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            if (spriteRenderer != null) spriteRenderer.flipX = true;
        }
    }
}