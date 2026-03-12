using UnityEngine;

public class CheckpointFlag : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            CheckpointManager.instance.SetCheckpoint(transform.position);
            activated = true;

            Debug.Log("Checkpoint activated at: " + transform.position);
        }
    }
}