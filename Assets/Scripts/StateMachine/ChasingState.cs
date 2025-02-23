using UnityEngine;
using UnityEngine.AI;
using VContainer;

public class ChasingState : IEnemyState
{
    private EnemyBase _enemy;
    private PlayerManager _playerManager;

    public ChasingState(EnemyBase enemy, PlayerManager playerManager)
    {
        _enemy = enemy;
        _playerManager = playerManager;
    }

    public void Enter() { }

    public void Update()
    {
        if (_playerManager.IsDead)
        {
            _enemy.SetState(new PatrollingState(_enemy, _playerManager));
            return;
        }
        
        float dist = Vector3.Distance(_enemy.transform.position, _playerManager.PlayerPosition);

        if (dist > _enemy.GetChasingRange)
        {
            _enemy.SetState(new IdleState(_enemy, _playerManager));
        }
        else
        {
            if (dist < _enemy.GetAttackRange)
            {
                _enemy.SetState(new AttackingState(_enemy, _playerManager));
            }
            else
            {
                _enemy.OnMove?.Invoke(_playerManager.PlayerPosition, _enemy.GetAttackRange);
            }
        }
    }

    public void Exit() { }
}