using VContainer;

public class MovementStrategyFactory
{
    public MovementStrategyFactory()
    {
        UnityEngine.Debug.Log("MovementStrategyFactory initialized");
    }

    public IMovementStrategy CreateStrategy(CharacterBase character)
    {
        return character switch
        {
            MeleeEnemy => new RunningNavMeshMovement(),
            EnemyBase => new NavMeshMovement(),
            Player => new InputMovement(),
            _ => new DefaultMovement()
        };
    }
}
