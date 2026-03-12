using UnityEngine;

public class BatFlyAcross : MonoBehaviour
{
    public float flySpeed = 6f;
    public Vector2 flyDirection = Vector2.left;
    public float destroyAfter = 5f;

    private bool isFlying = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        // Face the correct direction
        if (spriteRenderer != null)
        {
            if (flyDirection.x < 0)
                spriteRenderer.flipX = true;
            else if (flyDirection.x > 0)
                spriteRenderer.flipX = false;
        }
    }

    public void ActivateBat()
    {
        if (isFlying) return;

        isFlying = true;

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = flyDirection.normalized * flySpeed;
        }

        Destroy(gameObject, destroyAfter);
    }
}
