using UnityEngine;

public interface IHealth
{
    int CurrentHP { get; }
    void TakeDamage(int amount);
    void Heal(int amount);
    bool IsDead();
}
