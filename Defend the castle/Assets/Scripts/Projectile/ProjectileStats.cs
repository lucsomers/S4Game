using UnityEngine;

[CreateAssetMenu(fileName = "new projectile", menuName = "new Projectile")]
public class ProjectileStats : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private string projectileName;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private bool destroyOnImpact = true;

    [SerializeField] private string targetAbleTags = "Player";

    [Header("Graphics")]
    [SerializeField] private Sprite projectileSprite;

    public string ProjectileName { get => projectileName; private set => projectileName = value; }
    public int Damage { get => damage; private set => damage = value; }
    public float Speed { get => speed; private set => speed = value; }
    public string TargetAbleTags { get => targetAbleTags; private set => targetAbleTags = value; }
    public Sprite ProjectileSprite { get => projectileSprite; private set => projectileSprite = value; }
    public float LifeTime { get => lifeTime; private set => lifeTime = value; }
    public bool DestroyOnImpact { get => destroyOnImpact; private set => destroyOnImpact = value; }
}