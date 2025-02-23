using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using VContainer;

public class CharacterBase: MonoBehaviour, IHealth, IMovement
{
    [HideInInspector] public CharacterStats Stats;
    
    protected int _currentHealth;
    
    public int CurrentHP => _currentHealth;
    public bool IsDead() => CurrentHP <= 0;

    public void Initialize(CharacterStats stats)
    {
        Debug.LogError("Initialize CharacterBase<<<<<<<<<<<");
        Stats = stats;
        _currentHealth = stats.maxHealth;
    }
    
    public virtual void Move(Vector3 targetPosition)
    {
        Debug.Log("Moving character");
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("CharacterBase - Die");
        gameObject.SetActive(false);
    }
    
    public virtual void Heal(int amount)
    {
        _currentHealth += amount;
        Debug.Log($"CharacterBase - {_currentHealth}; Heal - {amount}");
    }
}
