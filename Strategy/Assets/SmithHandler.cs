using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithHandler : MonoBehaviour
{
    [SerializeField] private GameObject UpgradedSquire;
    [SerializeField] private int UpgradeCostWood;
    [SerializeField] private int UpgradeCostStone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            if (!collision.GetComponent<Character>().IsKnight)
            {
                if (ResourceManager.resources.CurrentAmountOfWood >= UpgradeCostWood && 
                    ResourceManager.resources.CurrentAmountOfStone >= UpgradeCostStone)
                {
                    Vector3 spawnPos = collision.transform.position;

                    Destroy(collision.gameObject);

                    GameObject tempUpgradedSquire = Instantiate(UpgradedSquire);
                    tempUpgradedSquire.transform.position = spawnPos;
                }
            }
        }
    }

    private void PayCost()
    {
        ResourceManager.resources.SubstractWood(UpgradeCostWood);
        ResourceManager.resources.SubstractStone(UpgradeCostStone);
    }
}
