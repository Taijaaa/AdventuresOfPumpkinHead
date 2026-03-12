using UnityEngine;

public class PumpkinSeed : MonoBehaviour
{
    public float lifeTime = 3f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            return;

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        Destroy(gameObject);
    }
}