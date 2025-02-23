public class EnemyDefaultAttacking: IAttackingStrategy
{
    private CharacterBase _character; 
    private PlayerManager _playerManager;
    
    public EnemyDefaultAttacking(CharacterBase character, PlayerManager playerManager)
    {
        _character = character;
        _playerManager = playerManager;
    }

    public void Attack()
    {
        _playerManager.TakeDamage(_character.Stats.damage);
        UnityEngine.Debug.Log("Attack");
    }
}