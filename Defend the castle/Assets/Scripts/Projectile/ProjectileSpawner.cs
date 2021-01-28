using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private Projectile projectile;

    private void Start()
    {
        projectile = GetComponent<Projectile>();
    }

    public void SpawnObject()
    {
        Projectile ToFire = ProjectileManager.instance.GetAvailableProjectile();

        //Set pos
        ToFire.transform.position = projectile.transform.position;

        //Set active
        ToFire.gameObject.SetActive(true);

        //Set stats for collision
        ToFire.SetStats(projectile.Stats.ProjectileStatsToSpawn);

        //Set target for our projectile
        ToFire.ProjectileMover.SetTarget(Vector3.zero);
    }
}