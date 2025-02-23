using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectileEnemyStats", menuName = "Stats/Projectile Enemy Stats")]
public class ProjectileEnemyStats : EnemyStats
{
    public Projectile projectilePrefab;
    public float projectileSpeed;
    public float timeAutoDestroy;
}
