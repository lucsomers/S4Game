using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemyState nextState;

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
        return true;
    }

    public virtual void EndState()
    {

    }

    public EnemyState NextState { get => nextState; set => nextState = value; }
    public EnemyManager Manager { get => manager; private set => manager = value; }
}