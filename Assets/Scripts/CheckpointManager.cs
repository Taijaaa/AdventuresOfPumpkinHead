using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public Vector3 currentCheckpoint;
    public bool hasCheckpoint = false;

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

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
        hasCheckpoint = true;
    }

    public void ClearCheckpoint()
    {
        hasCheckpoint = false;
        currentCheckpoint = Vector3.zero;
    }
}