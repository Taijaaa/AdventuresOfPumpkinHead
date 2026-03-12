using UnityEngine;

public class ShootButtonTrap : MonoBehaviour
{
    public TrapDropPlatform trapPlatform;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PumpkinSeed>() != null)
        {
            trapPlatform.TriggerFall();
            Destroy(other.gameObject);
        }
    }
}