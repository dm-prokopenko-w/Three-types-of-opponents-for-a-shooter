using UnityEngine;

public class EnemyRaycastAttacking: IAttackingStrategy
{
    private RaycastEnemyStats _stats;
    private CharacterBase _character;
    private PlayerManager _playerManager;
    private int _damage;

    public EnemyRaycastAttacking(CharacterBase character, PlayerManager playerManager)
    {
        _stats = character.Stats as RaycastEnemyStats;
        _playerManager = playerManager;
        _character = character;
    }

    public void Attack()
    {
        Vector3 direction = (_playerManager.PlayerPosition - _character.transform.position).normalized;
        RaycastHit hit;

        if (Physics.Raycast(_character.transform.position, direction, out hit, _stats.attackRange, _stats.raycastLayerMask))
        {
            if (hit.collider.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(_stats.damage);
                Debug.Log($"Hit player for {_stats.damage} damage!");
            }
        }
    }
}
