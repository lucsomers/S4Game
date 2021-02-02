using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public Projectile projectileToFire;

    public virtual void DoAttack(CharacterClass attackingClass)
    {
        
    }
}