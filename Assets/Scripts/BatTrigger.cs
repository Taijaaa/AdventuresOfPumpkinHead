using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    public BatFlyAcross[] batsToActivate;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;
        if (!other.CompareTag("Player")) return;

        hasTriggered = true;

        foreach (BatFlyAcross bat in batsToActivate)
        {
            if (bat != null)
            {
                bat.ActivateBat();
            }
        }
    }
}