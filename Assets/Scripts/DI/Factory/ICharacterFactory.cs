
using UnityEngine;

public interface ICharacterFactory
{
    EnemyBase CreateCharacter(string characterName, Vector3 position);
    void DestroyCharacter(EnemyBase enemy);
}