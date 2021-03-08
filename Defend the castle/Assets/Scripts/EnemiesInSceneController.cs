using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInSceneController : MonoBehaviour
{
    #region Singleton
    public static EnemiesInSceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [HideInInspector]
    public int EnemyInLevelCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameData.instance.Multiplayer)
        {
            foreach (EnemyManager enemy in GetComponentsInChildren<EnemyManager>())
            {
                enemy.SetVisible(false);
                EnemyInLevelCount++;
            }
        }
        else
        {
            foreach (EnemyManager enemy in GetComponentsInChildren<EnemyManager>())
            {
                enemy.gameObject.SetActive(false);

                if (PhotonNetwork.IsMasterClient)
                {
                    SetupManager.instance.SpawnInEnemy(enemy.transform.position, enemy.gameObject.name);
                    EnemyInLevelCount++;
                }
            }
        }
    }
}
