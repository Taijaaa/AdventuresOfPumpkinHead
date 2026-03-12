using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathReset : MonoBehaviour
{
    public float fallThreshold = -10f;

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;

        if (CheckpointManager.instance != null && CheckpointManager.instance.hasCheckpoint)
        {
            transform.position = CheckpointManager.instance.currentCheckpoint;
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