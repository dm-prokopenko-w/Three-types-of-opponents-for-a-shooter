using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class EnemyManager: ITickable
{
    private ICharacterFactory _enemyFactory;
    
    private MovementStrategyFactory _movement;
    private PlayerManager _playerManager;
    
    private List<EnemyBase> _activeEnemies = new();

    [Inject]
    public EnemyManager(MovementStrategyFactory movement, PlayerManager playerManager, 
        ICharacterFactory enemyFactory)
    {
        Debug.Log("EnemyManager initialized");
        _enemyFactory = enemyFactory;
        _movement = movement;
        //Test
        //SpawnEnemy("MeleeEnemy", RandomPosition());
        //SpawnEnemy("ProjectileEnemy", RandomPosition());
        SpawnEnemy("RaycastEnemy", RandomPosition());
    }

    private Vector3 RandomPosition() => new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10));
    
    public void SpawnEnemy(string characterName, Vector3 position)
    {
        var enemy = _enemyFactory.CreateCharacter(characterName, position);
        enemy.OnMove.AddListener((position, stopDist) =>
        {
            enemy.EnemyNavMeshAgent.stoppingDistance = stopDist;
            Move(enemy, position);
        });
        _activeEnemies.Add(enemy);
    }
    
    public void TakeDamage(EnemyBase enemy, int damage)
    {
        enemy.TakeDamage(damage);
        Debug.Log($"Player attack {enemy.gameObject.name}");
        
        if (enemy.IsDead())
        {
            RemoveEnemy(enemy);
        }
    }
    
    public void RemoveEnemy(EnemyBase enemy)
    {
        if (_activeEnemies.Contains(enemy))
        {
            _activeEnemies.Remove(enemy);
            _enemyFactory.DestroyCharacter(enemy);
        }
    }

    public void Move(EnemyBase enemy, Vector3 position)
    {
        var movementStrategy = _movement.CreateStrategy(enemy);
        movementStrategy.Move(enemy, position);
        enemy.Move(position);
    }

    public void Tick()
    {
        foreach (var enemy in _activeEnemies)
        {
            enemy.UpdateEnemy();
        }
    }
}