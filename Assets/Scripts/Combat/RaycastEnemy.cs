using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class RaycastEnemy : EnemyBase
{
    [Inject]
    public override void Initialize(EnemyStats stats, PlayerManager playerManager, 
        AttackingStrategyFactory attackingStrategyFactory)
    {
        base.Initialize(stats, playerManager, attackingStrategyFactory);
        Debug.Log("Initialize RaycastEnemy");
    }

    public override void Attack(PlayerManager player)
    {
        Debug.Log("Attack RaycastEnemy");
        _attackingStrategy.Attack();
    }
}
