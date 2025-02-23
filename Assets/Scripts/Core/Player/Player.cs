using UnityEngine;
using VContainer;

public class Player : CharacterBase, IPlayerAttack
{
    private EnemyManager _enemyManager;

    [Inject]
    public void Initialize(EnemyManager enemyManager, PlayerStats stats)
    {
        Debug.Log("Initialize CharacterBase");
        _enemyManager = enemyManager;
    }

    public void Attack(EnemyBase enemy)
    {
        _enemyManager.TakeDamage(enemy, Stats.damage);
    }
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Debug.LogError("Player taking damage - " + damage + "; Current HP = "  + _currentHealth);
    }
}