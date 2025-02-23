using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPrefabDatabase", menuName = "Database/Enemy Prefabs")]
public class EnemyPrefabDatabase : ScriptableObject
{
    public EnemyStats[] enemyPrefabs;

    public EnemyStats GetPrefab(string characterName)
    {
        foreach (var entry in enemyPrefabs)
        {
            if (entry.characterName == characterName)
                return entry;
        }
        return null;
    }
}