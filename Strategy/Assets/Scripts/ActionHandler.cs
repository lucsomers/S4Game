using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    [SerializeField] private GameObject ChopWood;
    [SerializeField] private GameObject ChopStone;

    public void StartChopWood()
    {
        ChopWood.SetActive(true);
    }

    public void StartChopStone()
    {
        ChopStone.SetActive(true);
    }

    public void EndChopWood()
    {
        ChopWood.SetActive(false);
    }

    public void EndChopStone()
    {
        ChopStone.SetActive(false);
    }
}
