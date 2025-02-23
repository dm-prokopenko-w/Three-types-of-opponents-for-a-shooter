using UnityEngine;

public class PatrollingState : IEnemyState
{
    private PlayerManager _playerManager;
    private EnemyBase _enemy;
    private Vector3 _targetPoint;
    private float _patrolRadius = 10f;
    
    public PatrollingState(EnemyBase enemy, PlayerManager playerManager)
    {
        _enemy = enemy;
        _playerManager = playerManager;
    }

    public void Enter()
    {
        SetNewPatrolPoint();
    }

    public void Update()
    {
        if (_playerManager.IsDead)
        {
            float distToTargetPoint = Vector3.Distance(_enemy.transform.position, _targetPoint);

            if (distToTargetPoint < 1)
            {
                _enemy.SetState(new IdleState(_enemy, _playerManager));
            }
            return;
        }

        float dist = Vector3.Distance(_enemy.transform.position, _playerManager.PlayerPosition);

        if (dist - 0.1f >= _enemy.GetAttackRange)
        {
            float distToTargetPoint = Vector3.Distance(_enemy.transform.position, _targetPoint);

            if (distToTargetPoint < 1)
            {
                _enemy.SetState(new IdleState(_enemy, _playerManager));
            }
        }
        else
        {
            _enemy.SetState(new AttackingState(_enemy, _playerManager));
        }
    }

    public void Exit() { }

    private void SetNewPatrolPoint()
    {
        _targetPoint = _enemy.transform.position + (Random.insideUnitSphere * _patrolRadius);
        _targetPoint.y = _enemy.transform.position.y;
        _enemy.OnMove?.Invoke(_targetPoint, 0);
    }
}