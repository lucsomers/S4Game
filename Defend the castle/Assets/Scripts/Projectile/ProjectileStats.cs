using UnityEngine;

[CreateAssetMenu(fileName = "new projectile", menuName = "new Projectile")]
public class ProjectileStats : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private string projectileName;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private string targetAbleTags;

    [Header("Graphics")]
    [SerializeField] private Sprite projectileSprite;

    public string ProjectileName { get => projectileName; private set => projectileName = value; }
    public int Damage { get => damage; private set => damage = value; }
    public float Speed { get => speed; private set => speed = value; }
    public string TargetAbleTags { get => targetAbleTags; private set => targetAbleTags = value; }
    public Sprite ProjectileSprite { get => projectileSprite; private set => projectileSprite = value; }
}