using UnityEngine;
using System.Collections;

public class FallingPlatformTop : MonoBehaviour
{
    public float fallDelay = 0.3f;

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

        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if player landed from above
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y < -0.5f)
                {
                    TriggerFall();
                    break;
                }
            }
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