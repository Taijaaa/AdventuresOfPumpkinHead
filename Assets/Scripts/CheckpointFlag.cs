using UnityEngine;

public class CheckpointFlag : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;
        if (!other.CompareTag("Player")) return;

        PlayerInventory inventory = other.GetComponent<PlayerInventory>();

        if (CheckpointManager.instance != null)
        {
            CheckpointManager.instance.SetCheckpoint(transform.position, inventory);
        }

        activated = true;
        Debug.Log("Checkpoint activated");
    }
}