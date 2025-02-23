using UnityEngine;
using VContainer;

public class IdleState : IEnemyState
{
    private PlayerManager _playerManager;
    private EnemyBase _enemy;
    private float _awaitTime = 1.5f;
    private float _lastAwaitTime;
    
    public IdleState(EnemyBase enemy, PlayerManager playerManager)
    {
        _enemy = enemy;
        _playerManager = playerManager;
    }

    public void Enter()
    {
        _lastAwaitTime = 0f;
    }

    public void Update()
    {
        _lastAwaitTime += Time.deltaTime;

        if (_lastAwaitTime >= _awaitTime)
        {
            _enemy.SetState(new PatrollingState(_enemy, _playerManager));
        }
    }

    public void Exit()
    {
    }
}   