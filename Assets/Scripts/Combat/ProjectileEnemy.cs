using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

public class ProjectileEnemy : EnemyBase
{
    public Transform BarrelMuzzle;
    
    [Inject]
    public override void Initialize(EnemyStats stats, PlayerManager playerManager, 
        AttackingStrategyFactory attackingStrategyFactory)
    {
        base.Initialize(stats, playerManager, attackingStrategyFactory);
        Debug.Log("Initialize ProjectileEnemy");
    }

    public override void Attack(PlayerManager player)
    {
        Debug.Log("Attack ProjectileEnemy");
        _attackingStrategy.Attack();
    }
}
