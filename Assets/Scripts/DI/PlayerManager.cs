using UnityEngine;
using VContainer;

public class PlayerManager
{
    private readonly PlayerStats _stats;
    private int _currentHealth;
    private Player _player;
    private IMovementStrategy _movementStrategy;

    [Inject]
    public PlayerManager(PlayerStats stats, MovementStrategyFactory movement)
    {
        Debug.Log("Player manager initialized");
        _stats = stats;
        _currentHealth = _stats.maxHealth;
        _player = Object.Instantiate(stats.player);
        _player.Initialize(_stats);
        _movementStrategy = movement.CreateStrategy(_player);
    }
    
    public Vector3 PlayerPosition => _player.transform.position;

    public void TakeDamage(int damage) => _player.TakeDamage(damage);

    public bool IsDead => _player.IsDead();
    
    public void Move(Vector3 position)
    {
        _movementStrategy.Move(_player, position);
        _player.Move(position);
    }
}