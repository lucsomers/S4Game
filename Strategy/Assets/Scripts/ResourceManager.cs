using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager resources;

    private int currentAmountOfWood = 0;
    private int currentAmountOfStone = 0;
    private int currentAmountOfPoints = 0;

    private void Awake()
    {
        if (resources == null)
        {
            resources = new ResourceManager();
        }
    }

    public void AddWood(int amount)
    {
        currentAmountOfWood += amount;
    }

    public void AddStone(int amount)
    {
        currentAmountOfStone += amount;
    }

    public void AddPoints(int amount)
    {
        currentAmountOfPoints += amount;
    }

    public bool SubstractWood(int amount)
    {
        if (currentAmountOfWood - amount >= 0)
        {
            currentAmountOfWood -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool SubstractStone(int amount)
    {
        if (currentAmountOfStone - amount >= 0)
        {
            currentAmountOfStone -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool SubstractPoints(int amount)
    {
        if (currentAmountOfPoints - amount >= 0)
        {
            currentAmountOfPoints -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int CurrentAmountOfWood { get => currentAmountOfWood; }
    public int CurrentAmountOfStone { get => currentAmountOfStone; }
    public int CurrentAmountOfPoints { get => currentAmountOfPoints; }
}
