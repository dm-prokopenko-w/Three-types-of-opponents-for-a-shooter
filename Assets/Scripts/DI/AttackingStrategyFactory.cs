using VContainer;

public class AttackingStrategyFactory
{
    private readonly ObjectPool _objectPool;
    private readonly PlayerManager _playerManager;

    public AttackingStrategyFactory(ObjectPool objectPool, PlayerManager playerManager)
    {
        UnityEngine.Debug.Log("AttackStrategyFactory initialized");
        _objectPool = objectPool;
        _playerManager = playerManager;
    }

    public IAttackingStrategy CreateStrategy(CharacterBase character)
    {
        return character switch
        {
            ProjectileEnemy => new ProjectileAttacking(_objectPool, character, _playerManager),
            RaycastEnemy => new EnemyRaycastAttacking(character, _playerManager),
            _ => new EnemyDefaultAttacking(character, _playerManager)
        };
    }
}