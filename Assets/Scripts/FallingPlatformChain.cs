using UnityEngine;
using System.Collections;

public class FallingPlatformChain : MonoBehaviour
{
    public float fallDelay = 0.1f;

    private Rigidbody2D rb;
    private bool hasStartedFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStartedFalling) return;

        FallingPlatformTop topPlatform = collision.gameObject.GetComponent<FallingPlatformTop>();
        FallingPlatformChain otherChain = collision.gameObject.GetComponent<FallingPlatformChain>();

        // Only react if hit by another falling platform
        if (topPlatform != null || otherChain != null)
        {
            TriggerFall();
        }
    }

    public void TriggerFall()
    {
        if (!hasStartedFalling)
        {
            StartCoroutine(FallRoutine());
        }
    }

    IEnumerator FallRoutine()
    {
        hasStartedFalling = true;
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}