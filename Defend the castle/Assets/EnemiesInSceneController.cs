using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (EnemyController enemy in GetComponentsInChildren<EnemyController>())
        {
            enemy.SetVisible(false);
        } 
    }
}
