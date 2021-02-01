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
    [SerializeField] private bool ignoresWalls = false;
    [SerializeField] private bool isHealing = false;
    [SerializeField] private string targetAbleTags = "Player";

    [Header("Multi shot")]
    [SerializeField] private bool isMultishot = false;
    [SerializeField] private int amountOfInstances;
    [SerializeField] private float spreadMax;
    [SerializeField] private float spreadMin;


    [Header("AOE")]
    [SerializeField] private bool isAOE = false;
    [SerializeField] private float aoeSize = 0.10f;

    [Header("Object spawning")]
    [SerializeField] private bool spawnsObjectAtEndOfLifetime;
    [SerializeField] private bool spawnObjectAtCollision;
    [SerializeField] private ProjectileStats projectileStatsToSpawn;

    [Header("Graphics")]
    [SerializeField] private Sprite projectileSprite;

    public string ProjectileName { get => projectileName; private set => projectileName = value; }
    public int Damage { get => damage; private set => damage = value; }
    public float Speed { get => speed; private set => speed = value; }
    public string TargetAbleTags { get => targetAbleTags; private set => targetAbleTags = value; }
    public Sprite ProjectileSprite { get => projectileSprite; private set => projectileSprite = value; }
    public float LifeTime { get => lifeTime; private set => lifeTime = value; }
    public bool DestroyOnImpact { get => destroyOnImpact; private set => destroyOnImpact = value; }
    public bool SpawnsObjectAtEndOfLifetime { get => spawnsObjectAtEndOfLifetime; private set => spawnsObjectAtEndOfLifetime = value; }
    public bool SpawnObjectAtCollision { get => spawnObjectAtCollision; private set => spawnObjectAtCollision = value; }
    public ProjectileStats ProjectileStatsToSpawn { get => projectileStatsToSpawn; set => projectileStatsToSpawn = value; }
    public bool IsHealing { get => isHealing; private set => isHealing = value; }
    public bool IgnoresWalls { get => ignoresWalls; private set => ignoresWalls = value; }
    public float AOESize { get => aoeSize; private set => aoeSize = value; }
    public bool IsAOE { get => isAOE; set => isAOE = value; }
    public bool IsMultishot { get => isMultishot; set => isMultishot = value; }
    public int AmountOfInstances { get => amountOfInstances; set => amountOfInstances = value; }
    public float SpreadMax { get => spreadMax; set => spreadMax = value; }
    public float SpreadMin { get => spreadMin; set => spreadMin = value; }
}