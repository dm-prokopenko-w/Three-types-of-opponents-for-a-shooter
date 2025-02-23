using UnityEngine;
using UnityEngine.Serialization;

public abstract class EnemyStats : CharacterStats
{
    public float attackRange;
    public float chasingRange;
    public float attackCooldown;
    public EnemyBase enemyBase;
}