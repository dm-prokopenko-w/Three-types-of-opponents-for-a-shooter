using UnityEngine;

public class AttackingState : IEnemyState
{
    private EnemyBase _enemy;
    private PlayerManager _playerManager;
    private float _attackCooldown;
    private float _lastAttackTime;

    public AttackingState(EnemyBase enemy, PlayerManager playerManager)
    {
        _enemy = enemy;
        _playerManager = playerManager;
        _attackCooldown = ((EnemyStats)enemy.Stats).attackCooldown;
    }

    public void Enter()
    {
        _lastAttackTime = Time.time;
    }

    public void Update()
    {
        if (Time.time - _lastAttackTime > _attackCooldown)
        {
            _enemy.transform.LookAt(_playerManager.PlayerPosition);
            _enemy.Attack(_playerManager);
            _lastAttackTime = Time.time;

            if (_playerManager.IsDead)
            {
                _enemy.SetState(new IdleState(_enemy, _playerManager));
            }
        }

        float dist = Vector3.Distance(_enemy.transform.position, _playerManager.PlayerPosition);

        if (dist > _enemy.GetAttackRange)
        {
            if (dist > _enemy.GetChasingRange)
            {
                _enemy.SetState(new IdleState(_enemy, _playerManager));
            }
            else
            {
                _enemy.SetState(new ChasingState(_enemy, _playerManager));
            }
        }
    }

    public void Exit() { }
}