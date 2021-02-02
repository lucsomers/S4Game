using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAOEHandler : MonoBehaviour
{
    private CircleCollider2D aoeCollider;
    private Projectile projectile;

    private float aoeStartSize;

    private void Start()
    {
        aoeCollider = GetComponent<CircleCollider2D>();
        aoeStartSize = aoeCollider.radius;

        projectile = GetComponentInParent<Projectile>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (projectile.Stats.IsAOE)
        {
            projectile.ProjectileCollision.HandleCollision(collision, true);
        }
    }

    public void Turn_On_AOE()
    {
        if (projectile != null && projectile.Stats != null)
        {
            aoeCollider.radius = projectile.Stats.AOESize;
            aoeCollider.enabled = true;
            projectile.ProjectileCollision.SetActiveCollider(false);
        }
    }

    public void Turn_Off_AOE()
    {
        if (projectile != null && projectile.Stats != null)
        {
            aoeCollider.radius = aoeStartSize;
            aoeCollider.enabled = false;
            projectile.ProjectileCollision.SetActiveCollider(true);
        }
    }
}
