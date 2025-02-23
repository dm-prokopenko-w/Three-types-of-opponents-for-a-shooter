using UnityEngine;
using VContainer;

public class EnemyFactory: ICharacterFactory
{
    private readonly EnemyManager _enemyManager;
    private readonly ObjectPool _objectPool;
    private readonly AttackingStrategyFactory _attackingStrategyFactory;
    private readonly EnemyPrefabDatabase _enemyPrefabDatabase;
    private readonly PlayerManager _player;
    private Transform _parentEnemy;

    [Inject]
    public EnemyFactory(EnemyPrefabDatabase enemyPrefabDatabase, PlayerManager player, ObjectPool objectPool, 
        AttackingStrategyFactory attackingStrategyFactory)
    {
        Debug.Log("EnemyFactory initialized");
        _attackingStrategyFactory = attackingStrategyFactory;
        _objectPool = objectPool;
        _player = player;
        _enemyPrefabDatabase = enemyPrefabDatabase;
        _parentEnemy = new GameObject("ParentEnemy").transform;
    }

    public EnemyBase CreateCharacter(string characterName, Vector3 position)
    {
        var stats = _enemyPrefabDatabase.GetPrefab(characterName);
        if (stats == null || stats.enemyBase == null)
        {
            Debug.LogError($"Prefab for enemy type {stats.enemyBase} not found!");
            return null;
        }

        var enemyInstance = 
            _objectPool.Spawn(stats.enemyBase.gameObject, position, Quaternion.identity, _parentEnemy);
        var enemyBase = enemyInstance.GetComponent<EnemyBase>();

        if (enemyBase != null)
        {
            enemyBase.Initialize(stats, _player, _attackingStrategyFactory);
        }

        return enemyBase;
    }

    public void DestroyCharacter(EnemyBase enemy)
    {
        _objectPool.Despawn(enemy.gameObject);
    }
}
