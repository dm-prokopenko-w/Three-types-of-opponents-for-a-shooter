using UnityEngine;

public class EnemyStateMachine
{
    private readonly IEnemyState _initialState;
    private IEnemyState _currentState;

    public EnemyStateMachine(IEnemyState initialState)
    {
        _initialState = initialState;
        _currentState = initialState;
    }

    public void ChangeState(IEnemyState newState)
    {
        Debug.Log("IEnemyState - " + newState);
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void UpdateState()
    {
        _currentState.Update();
    }
}