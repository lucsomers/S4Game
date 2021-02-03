using UnityEngine;
using System.Collections;

public class EnemyLineOfSight
{
    public bool CanSeePlayer(EnemyManager Manager, Vector3 startPos, PlayerController player, LayerMask layersToHit, float range)
    {
        bool playerInLineOfSight = false;

        RaycastHit2D hit = Physics2D.Raycast(startPos, player.transform.position - startPos, range, layersToHit);

        if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Player"))
            {
                if (!player.Invisible)
                {
                    //Player is not invisible so we are visible to player and in line of sight
                    Manager.SetVisible(true);
                    playerInLineOfSight = true;
                }
                else
                {
                    //Player is invisible so we are visible to player but not in line of sight
                    Manager.SetVisible(true);
                    playerInLineOfSight = false;
                }
            }
            else
            {
                playerInLineOfSight = false;

                Manager.SetVisible(false);
            }
        }

        CanSeePlayerOnline(Manager, startPos, player, layersToHit, range);

        return playerInLineOfSight;
    }

    private void CanSeePlayerOnline(EnemyManager Manager, Vector3 startPos, PlayerController player, LayerMask layersToHit, float range)
    {
        if (GameData.instance.Multiplayer)
        {
            foreach (PlayerController playerdif in SetupManager.instance.PlayersInGame)
            {
                RaycastHit2D visionHit = Physics2D.Raycast(startPos, playerdif.transform.position - startPos, range, layersToHit);
                if (visionHit.transform != null)
                {
                    if (visionHit.transform.CompareTag("Player"))
                    {
                        if (!player.Invisible)
                        {
                            //Player is not invisible so we are visible to player and in line of sight
                            Manager.SetVisible(true);
                        }
                        else
                        {
                            //Player is invisible so we are visible to player but not in line of sight
                            Manager.SetVisible(true);
                        }
                        break;
                    }
                    else
                    {
                        Manager.SetVisible(false);
                    }
                }
            }
        }
    }
}
