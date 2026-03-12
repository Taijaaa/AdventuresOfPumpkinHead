using UnityEngine;

public class PumpkinSeed : MonoBehaviour
{
    public float lifeTime = 3f;
    public int damage = 1;

    private bool hasHit = false;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        if (other.CompareTag("Player"))
            return;

        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();

        if (enemy != null)
        {
            hasHit = true;
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        hasHit = true;
        Destroy(gameObject);
    }
}