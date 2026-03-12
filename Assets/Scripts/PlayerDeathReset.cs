using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathReset : MonoBehaviour
{
    public float fallThreshold = -10f;

    void Start()
    {
        if (CheckpointManager.instance != null)
        {
            if (CheckpointManager.instance.hasCheckpoint)
            {
                transform.position = CheckpointManager.instance.currentCheckpoint;
            }

            PlayerInventory inventory = GetComponent<PlayerInventory>();
            CheckpointManager.instance.LoadInventory(inventory);
        }
    }

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            ResetPlayer();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayer();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            ResetPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}