using UnityEngine;

public class BatFlyAcross : MonoBehaviour
{
    public float flySpeed = 6f;
    public Vector2 flyDirection = Vector2.left;
    public float destroyAfter = 5f;

    private bool isFlying = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.zero;
        }

        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        if (col != null)
            col.enabled = false;
    }

    public void ActivateBat()
    {
        if (isFlying) return;
        isFlying = true;

        if (spriteRenderer != null)
            spriteRenderer.enabled = true;

        if (col != null)
            col.enabled = true;

        if (spriteRenderer != null)
        {
            if (flyDirection.x < 0)
                spriteRenderer.flipX = true;
            else if (flyDirection.x > 0)
                spriteRenderer.flipX = false;
        }

        if (rb != null)
            rb.linearVelocity = flyDirection.normalized * flySpeed;

        Destroy(gameObject, destroyAfter);
    }
}