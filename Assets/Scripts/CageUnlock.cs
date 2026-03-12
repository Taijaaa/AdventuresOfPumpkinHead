using UnityEngine;
using UnityEngine.SceneManagement;

public class CageUnlock : MonoBehaviour
{
    public bool unlocksWithKey = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        if (inventory == null) return;

        if (unlocksWithKey && inventory.hasKey)
        {
            inventory.UseKey();

            Debug.Log("Cage unlocked! You win!");

            // Win action
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("You need the key!");
        }
    }
}