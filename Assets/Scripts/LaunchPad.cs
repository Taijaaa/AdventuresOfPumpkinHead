using UnityEngine;
using System.Collections;

public class LaunchPad : MonoBehaviour
{
    public float launchX = 0f;
    public float launchY = 20f;
    public float deathDelay = 1.5f;

    private Rigidbody2D rb;
    private bool hasLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLaunched) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            hasLaunched = true;

            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            PlayerDeathReset deathReset = collision.gameObject.GetComponent<PlayerDeathReset>();

            // Make player stick to platform
            collision.transform.SetParent(transform);

            // Launch platform
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(launchX, launchY);
            }

            // Match player velocity too
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(launchX, launchY);
            }

            // Reset after delay
            if (deathReset != null)
            {
                StartCoroutine(KillPlayerAfterDelay(collision.transform, deathReset));
            }
        }
    }

    IEnumerator KillPlayerAfterDelay(Transform playerTransform, PlayerDeathReset deathReset)
    {
        yield return new WaitForSeconds(deathDelay);

        // Unparent before reset
        if (playerTransform != null)
        {
            playerTransform.SetParent(null);
        }

        deathReset.ResetPlayer();
    }
}