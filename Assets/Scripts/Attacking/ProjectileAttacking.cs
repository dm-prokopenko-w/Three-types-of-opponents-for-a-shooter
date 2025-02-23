using UnityEngine;

public class ProjectileAttacking : IAttackingStrategy
{
    private ObjectPool _objectPool;
    private Projectile _projectile; 
    private ProjectileEnemy _character;
    private float _projectileSpeed;
    private float _timeAutoDestroy;
    private Transform _projectileTransform;
    private PlayerManager _playerManager;
    
    public ProjectileAttacking(ObjectPool objectPool, CharacterBase character, PlayerManager playerManager)
    {
        _objectPool = objectPool;
        _character = (ProjectileEnemy)character;
        _playerManager = playerManager;
        _projectileSpeed = ((ProjectileEnemyStats)character.Stats).projectileSpeed;
        _timeAutoDestroy = ((ProjectileEnemyStats)character.Stats).timeAutoDestroy;
        _projectile = ((ProjectileEnemyStats)character.Stats).projectilePrefab;
        _projectileTransform = new GameObject(_projectile.name).transform;
        _objectPool.Preload(_projectile.gameObject, _projectileTransform, 5);
    }
    
    public void Attack()
    {
        var dir = _playerManager.PlayerPosition - _character.BarrelMuzzle.position;
        dir.y = 0;
        var go = _objectPool.Spawn(_projectile.gameObject, _character.BarrelMuzzle.position, Quaternion.identity, _projectileTransform);
        go.GetComponent<Projectile>().Initialize(
            dir * _projectileSpeed, 
            _timeAutoDestroy,
            (collider =>
            {
                if (collider != null)
                {
                    Debug.LogError("collider " + collider.gameObject.name);
                }
                else
                {
                    Debug.Log("collider = null");
                }
                if (collider != null && collider.TryGetComponent(out Player player))
                {
                    player.TakeDamage(_character.Stats.damage);
                    Debug.Log($"Hit player for {_character.Stats.damage} damage!");
                }
                _objectPool.Despawn(go);
            }));
    }
}