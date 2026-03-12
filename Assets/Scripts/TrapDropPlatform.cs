using UnityEngine;
using System.Collections;

public class TrapDropPlatform : MonoBehaviour
{
    public float fallDelay = 0.3f;

    [Header("Mini Goblin Spawn")]
    public GameObject miniGoblinPrefab;
    public Transform spawnPoint;
    public int goblinsToSpawn = 3;

    [Header("Trap Cleanup")]
    public float destroyDelay = 1f;

    private Rigidbody2D rb;
    private bool hasFallen = false;
    private bool hasSpawned = false;
    private bool hasSquishedEnemy = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void TriggerFall()
    {
        if (!hasFallen)
        {
            StartCoroutine(FallRoutine());
        }
    }

    IEnumerator FallRoutine()
    {
        hasFallen = true;
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasFallen) return;

        // Kill goblin / enemy under platform
        if (!hasSquishedEnemy && collision.gameObject.CompareTag("Hazard"))
        {
            hasSquishedEnemy = true;

            Destroy(collision.gameObject);

            if (!hasSpawned)
            {
                SpawnMiniGoblins();
                hasSpawned = true;
            }

            StartCoroutine(DestroyTrapAfterDelay());
            return;
        }

        // Optional fallback: if it hits ground first, still spawn goblins
        if (!hasSpawned && collision.gameObject.CompareTag("Ground"))
        {
            SpawnMiniGoblins();
            hasSpawned = true;
        }
    }

    void SpawnMiniGoblins()
    {
        if (miniGoblinPrefab == null || spawnPoint == null) return;

        for (int i = 0; i < goblinsToSpawn; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), 0.2f, 0f);
            Instantiate(miniGoblinPrefab, spawnPoint.position + offset, Quaternion.identity);
        }
    }

    IEnumerator DestroyTrapAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}