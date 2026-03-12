using UnityEngine;

public class PumpkinSeedShooter : MonoBehaviour
{
    [Header("Shooting Setup")]
    public GameObject seedPrefab;
    public Transform firePoint;
    public float seedSpeed = 10f;

    [Header("Cooldown")]
    public float shootCooldown = 1.5f;
    private float nextShootTime = 0f;

    private PlayerInventory inventory;
    private Camera mainCamera;

    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (inventory == null) return;
        if (!inventory.hasPumpkinShooter) return;

        if (Input.GetMouseButtonDown(0) && Time.time >= nextShootTime)
        {
            ShootSeed();
            nextShootTime = Time.time + shootCooldown;
        }
    }

    void ShootSeed()
    {
        if (seedPrefab == null)
        {
            Debug.LogWarning("Seed Prefab is missing!");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogWarning("FirePoint is missing!");
            return;
        }

        if (mainCamera == null)
        {
            Debug.LogWarning("Main Camera not found!");
            return;
        }

        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;

        Vector2 direction = (mouseWorldPosition - firePoint.position).normalized;

        GameObject seed = Instantiate(seedPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = seed.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * seedSpeed;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        seed.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}