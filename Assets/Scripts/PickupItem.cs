using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public enum PickupType
    {
        Candy,
        Key,
        PumpkinShooter
    }

    public PickupType pickupType;
    public int candyValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        if (inventory == null) return;

        if (pickupType == PickupType.Candy)
        {
            inventory.AddCandy(candyValue);
        }
        else if (pickupType == PickupType.Key)
        {
            inventory.CollectKey();
        }
        else if (pickupType == PickupType.PumpkinShooter)
        {
            inventory.CollectPumpkinShooter();
        }

        Destroy(gameObject);
    }
}