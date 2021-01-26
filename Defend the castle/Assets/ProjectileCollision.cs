using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private Projectile projectile;

    private void Awake()
    {
        projectile = GetComponent<Projectile>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(projectile.Stats.TargetAbleTags))
        {
            Debug.Log("Hit");

            if (projectile.Stats.DestroyOnImpact)
            {
                projectile.DestroySelf();
            }
        }
    }
}
