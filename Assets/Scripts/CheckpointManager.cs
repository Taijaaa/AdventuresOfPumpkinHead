using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public Vector3 currentCheckpoint;
    public bool hasCheckpoint = false;

    [Header("Saved Inventory At Checkpoint")]
    public bool savedHasKey = false;
    public bool savedHasPumpkinShooter = false;
    public int savedCandyCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint, PlayerInventory inventory)
    {
        currentCheckpoint = newCheckpoint;
        hasCheckpoint = true;

        if (inventory != null)
        {
            savedHasKey = inventory.hasKey;
            savedHasPumpkinShooter = inventory.hasPumpkinShooter;
            savedCandyCount = inventory.candyCount;
        }

        Debug.Log("Checkpoint saved. Key: " + savedHasKey + ", Shooter: " + savedHasPumpkinShooter + ", Candy: " + savedCandyCount);
    }

    public void LoadInventory(PlayerInventory inventory)
    {
        if (inventory == null) return;

        if (hasCheckpoint)
        {
            inventory.hasKey = savedHasKey;
            inventory.hasPumpkinShooter = savedHasPumpkinShooter;
            inventory.candyCount = savedCandyCount;
        }
        else
        {
            inventory.hasKey = false;
            inventory.hasPumpkinShooter = false;
            inventory.candyCount = 0;
        }
    }
}