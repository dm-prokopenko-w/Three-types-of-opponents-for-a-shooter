using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using VContainer;

public abstract class EnemyBase : CharacterBase, IEnemyAttack
{
    [HideInInspector] public NavMeshAgent EnemyNavMeshAgent;

    [HideInInspector] public UnityEvent<Vector3, float> OnMove = new();
    
    protected PlayerManager _playerManager;
    protected EnemyStateMachine enemyStateMachine;
    protected AttackingStrategyFactory _attackingStrategyFactory;
    protected IAttackingStrategy _attackingStrategy;
    public float GetAttackRange => ((EnemyStats)Stats).attackRange;
    public float GetChasingRange => ((EnemyStats)Stats).chasingRange;

    [Inject]
    public virtual void Initialize(EnemyStats stats, PlayerManager playerManager, 
        AttackingStrategyFactory attackingStrategyFactory)
    {
        Debug.Log("Initialize EnemyBase");
        _playerManager = playerManager;
        Stats = stats;
        EnemyNavMeshAgent = GetComponent<NavMeshAgent>();
        EnemyNavMeshAgent.stoppingDistance = 1;

        enemyStateMachine = new EnemyStateMachine(new IdleState(this, _playerManager));
        _attackingStrategyFactory = attackingStrategyFactory;
        _attackingStrategy = _attackingStrategyFactory.CreateStrategy(this);
    }

    public abstract void Attack(PlayerManager player);
    
    public void SetState(IEnemyState state) => enemyStateMachine.ChangeState(state);
    
    public void UpdateEnemy()
    {
        enemyStateMachine.UpdateState();
    }
}