using UnityEngine;
using System.Collections;

public class TombstoneZombieTrap : MonoBehaviour
{
    [Header("Zombie Hand")]
    public Transform zombieHand;
    public Vector3 hiddenPositionOffset = new Vector3(0f, -1f, 0f);
    public Vector3 risePositionOffset = new Vector3(0f, 0f, 0f);

    [Header("Timing")]
    public float riseSpeed = 3f;
    public float killDelay = 0.2f;

    private Vector3 hiddenPosition;
    private Vector3 risePosition;
    private bool triggered = false;

    void Start()
    {
        if (zombieHand != null)
        {
            risePosition = zombieHand.position + risePositionOffset;
            hiddenPosition = zombieHand.position + hiddenPositionOffset;
            zombieHand.position = hiddenPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(RiseAndKill(other.gameObject));
        }
    }

    IEnumerator RiseAndKill(GameObject player)
    {
        if (zombieHand != null)
        {
            while (Vector3.Distance(zombieHand.position, risePosition) > 0.01f)
            {
                zombieHand.position = Vector3.MoveTowards(
                    zombieHand.position,
                    risePosition,
                    riseSpeed * Time.deltaTime
                );

                yield return null;
            }
        }

        yield return new WaitForSeconds(killDelay);

        PlayerDeathReset deathReset = player.GetComponent<PlayerDeathReset>();
        if (deathReset != null)
        {
            deathReset.ResetPlayer();
        }
    }
}