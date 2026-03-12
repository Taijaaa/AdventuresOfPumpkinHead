using UnityEngine;

public class TombstoneZombieChase : MonoBehaviour
{
    [Header("References")]
    public GameObject zombie;
    public Transform player;

    [Header("Zombie Settings")]
    public float moveSpeed = 2f;

    private bool chasing = false;
    private Rigidbody2D zombieRb;
    private SpriteRenderer zombieSprite;
    private Collider2D zombieCollider;

    void Start()
    {
        if (zombie != null)
        {
            zombieRb = zombie.GetComponent<Rigidbody2D>();
            zombieSprite = zombie.GetComponent<SpriteRenderer>();
            zombieCollider = zombie.GetComponent<Collider2D>();

            zombie.SetActive(false);
        }
    }

    void Update()
    {
        if (!chasing || zombie == null || player == null) return;

        float directionX = Mathf.Sign(player.position.x - zombie.transform.position.x);

        if (zombieRb != null)
        {
            zombieRb.linearVelocity = new Vector2(directionX * moveSpeed, zombieRb.linearVelocity.y);
        }

        if (zombieSprite != null)
        {
            zombieSprite.flipX = directionX < 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (zombie == null) return;

        zombie.SetActive(true);

        if (zombieCollider != null)
        {
            zombieCollider.enabled = true;
        }

        chasing = true;
    }
}