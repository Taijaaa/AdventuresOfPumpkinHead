using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Rigidbody2D rb;
    private Vector2 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (pointA == null || pointB == null)
        {
            Debug.LogWarning("PointA or PointB is missing on " + gameObject.name);
            enabled = false;
            return;
        }

        targetPosition = pointB.position;
    }

    void FixedUpdate()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if (Vector2.Distance(rb.position, targetPosition) < 0.05f)
        {
            if (targetPosition == (Vector2)pointA.position)
                targetPosition = pointB.position;
            else
                targetPosition = pointA.position;
        }
    }
}