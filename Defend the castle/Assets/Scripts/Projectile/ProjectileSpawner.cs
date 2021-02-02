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
        Vector3 startPosition = projectile.transform.position;

        ProjectileStats ps = projectile.Stats.ProjectileStatsToSpawn;

        Vector3 target = Vector3.zero;

        ProjectileManager.instance.CreateProjectile(startPosition, target, ps);
    }
}