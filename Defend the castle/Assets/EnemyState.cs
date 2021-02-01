using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemyState nextState;

    private bool goToDefaultState = false;

    private EnemyManager manager;

    public virtual void StartState()
    {
        manager = GetComponentInParent<EnemyManager>();
    }

    public virtual void UpdateState()
    {

    }

    public virtual bool CheckForStateEnd()
    {
        Debug.Log("We are in end state parent");
        return true;
    }

    public virtual void EndState()
    {

    }

    public bool CanSeePlayer(Vector3 startPos, PlayerController player, LayerMask layersToHit, float range)
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

        return playerInLineOfSight;
    }

    public EnemyState NextState { get => nextState; set => nextState = value; }
    public EnemyManager Manager { get => manager; private set => manager = value; }
    public bool GoToDefaultState { get => goToDefaultState; set => goToDefaultState = value; }
}