using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemyState nextState;

    private bool goToDefaultState = false;

    private EnemyManager manager;

    private EnemyLineOfSight lineOfSight;

    private void Start()
    {
        lineOfSight = new EnemyLineOfSight();
    }

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

    public EnemyState NextState { get => nextState; set => nextState = value; }
    public EnemyManager Manager { get => manager; private set => manager = value; }
    public bool GoToDefaultState { get => goToDefaultState; set => goToDefaultState = value; }
    public EnemyLineOfSight LineOfSight { get => lineOfSight; set => lineOfSight = value; }
}