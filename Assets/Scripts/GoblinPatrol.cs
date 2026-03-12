using UnityEngine;

public class GoblinPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform targetPoint;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPoint = pointB;

        if (pointA == null || pointB == null)
        {
            Debug.LogWarning("Patrol points are missing on " + gameObject.name);
        }
    }

    void Update()
    {
        if (pointA == null || pointB == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }

        if (spriteRenderer != null)
        {
            if (targetPoint.position.x > transform.position.x)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;
        }
    }
}