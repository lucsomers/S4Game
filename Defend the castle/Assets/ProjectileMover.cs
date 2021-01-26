using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    private Projectile projectile;

    private float currentLifeTime = 0;

    private Vector3 normalizeDirection;

    private void Awake()
    {
        projectile = GetComponent<Projectile>();
    }

    private void Update()
    {
        if (projectile.IsMoving)
        {
            MoveToTarget();

            currentLifeTime -= Time.deltaTime;

            if (currentLifeTime <= 0)
            {
                currentLifeTime = 0;
                projectile.IsMoving = false;
                EndOfLifeTime();
            }
        }
    }

    private void EndOfLifeTime()
    {
        projectile.DestroySelf();
    }

    private void MoveToTarget()
    {
        transform.position += normalizeDirection * projectile.Stats.Speed * Time.deltaTime;

        //transform.position = Vector2.MoveTowards(transform.position, target, stats.Speed * Time.deltaTime);
    }

    public void SetTarget(Vector3 target)
    {
        projectile.Target = target;

        normalizeDirection = ((Vector3)target - transform.position).normalized;

        //Got this from: https://answers.unity.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html
        var dir = target - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
