using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    #region SingleTon
    public static ProjectileManager instance;

    private void Awake()
    {
        if (instance != this || instance == null)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] private GameObject PrefabProjectile;
    [SerializeField] private int StartAmountInPool = 40;

    List<Projectile> ProjectTiles = new List<Projectile>();

    private void Start()
    {
        for (int i = 0; i < StartAmountInPool; i++)
        {
            ProjectTiles.Add(CreateNewPrefabProjectile());
        }
    }

    public Projectile GetAvailableProjectile()
    {
        Projectile toReturn = null;

        foreach (Projectile projectileToAdd in ProjectTiles)
        {
            if (!projectileToAdd.gameObject.activeSelf)
            {
                toReturn = projectileToAdd;
                break;
            }
        }

        if (toReturn == null)
        {
            //No available instanciate new one;
            toReturn = CreateNewPrefabProjectile();
        }

        return toReturn;
    }

    private Projectile CreateNewPrefabProjectile()
    {
        Projectile toReturn;

        GameObject temp = GameObject.Instantiate(PrefabProjectile, transform);
        toReturn = temp.GetComponent<Projectile>();

        ProjectTiles.Add(toReturn);

        temp.SetActive(false);

        return toReturn;
    }
}