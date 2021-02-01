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

        DontDestroyOnLoad(this.gameObject);
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

    public void CreateProjectile(Vector3 startPosition, Vector3 target, ProjectileStats projectileStats)
    {
        FireProjectile(startPosition, target, projectileStats);

        if (projectileStats.IsMultishot)
        {
            float x_offset = 0;
            float y_offset = 0;

            // we make amount - 1 because we already created the first one
            for (int i = 0; i < projectileStats.AmountOfInstances - 1; i++)
            {
                x_offset = GetDifferentRandomNumber(projectileStats, x_offset, i);
                y_offset = GetDifferentRandomNumber(projectileStats, y_offset, i);

                Vector3 newTarget = new Vector3(target.x + x_offset, target.y + y_offset, target.z);

                FireProjectile(startPosition, newTarget, projectileStats);
            }
        }
    }

    private float GetDifferentRandomNumber(ProjectileStats projectileStats, float lastOffset, int i)
    {
        float random_Offset = Random.Range(projectileStats.SpreadMin, projectileStats.SpreadMax);

        while (random_Offset == lastOffset)
        {
            random_Offset = Random.Range(projectileStats.SpreadMin, projectileStats.SpreadMax);;
        }

        return random_Offset;

    }

    private void FireProjectile(Vector3 startPosition, Vector3 target, ProjectileStats projectileStats)
    {
        Projectile ToFire = GetAvailableProjectile();

        //Set pos
        ToFire.transform.position = startPosition;

        //Set stats for collision
        ToFire.SetStats(projectileStats);

        //Set active
        ToFire.gameObject.SetActive(true);

        //Set target for our projectile
        ToFire.ProjectileMover.SetTarget(target);
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