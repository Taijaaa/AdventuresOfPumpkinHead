using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int candyCount = 0;
    public bool hasKey = false;
    public bool hasPumpkinShooter = false;

    public void AddCandy(int amount)
    {
        candyCount += amount;
    }

    public void CollectKey()
    {
        hasKey = true;
    }

    public void UseKey()
    {
        hasKey = false;
    }

    public void CollectPumpkinShooter()
    {
        hasPumpkinShooter = true;
    }
}