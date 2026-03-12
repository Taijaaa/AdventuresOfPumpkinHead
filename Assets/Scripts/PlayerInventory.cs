using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int candyCount = 0;
    public bool hasKey = false;
    public bool hasPumpkinShooter = false;

    public void AddCandy(int amount)
    {
        candyCount += amount;
        Debug.Log("Candy: " + candyCount);
    }

    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");
    }

    public void UseKey()
    {
        hasKey = false;
    }

    public void CollectPumpkinShooter()
    {
        hasPumpkinShooter = true;
        Debug.Log("Pumpkin Seed Shooter collected!");
    }
}