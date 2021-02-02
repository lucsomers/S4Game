using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLineOfSight : MonoBehaviour
{
    [SerializeField] private LayerMask ignoredLayers;
    private PlayerController player;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyController enemy = CheckEnemyInSight(collision);

        if (enemy != null)
        {
            if (!enemy.IsVisible)
            {
                 enemy.SetVisible(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyController enemy = CheckEnemyInSight(collision);

        if (enemy != null)
        {
            enemy.SetVisible(false);
        }
    }

    private EnemyController CheckEnemyInSight(Collider2D collision)
    {
        EnemyController enemy = null;

        RaycastHit2D hit = Physics2D.Raycast(player.transform.position,  collision.transform.position - player.transform.position, 1000f, ignoredLayers);
        
        Debug.DrawRay(player.transform.position, collision.transform.position - player.transform.position, Color.red, 0.1f);

        if (hit.transform.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<EnemyController>();
        }

        return enemy;
    }
}
