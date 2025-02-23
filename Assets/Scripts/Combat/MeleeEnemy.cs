using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

public class MeleeEnemy : EnemyBase
{
    [Inject]
    public override void Initialize(EnemyStats stats, PlayerManager playerManager, 
        AttackingStrategyFactory attackingStrategyFactory)
    {
        base.Initialize(stats, playerManager, attackingStrategyFactory);
        Debug.Log("Initialize MeleeEnemy");
    }

    public override void Attack(PlayerManager player)
    {
        Debug.Log("Attack MeleeEnemy");
        _attackingStrategy.Attack();
    }
}
