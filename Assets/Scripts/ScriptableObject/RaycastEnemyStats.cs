using UnityEngine;

[CreateAssetMenu(fileName = "NewRaycastEnemyStats", menuName = "Stats/Raycast Enemy Stats")]
public class RaycastEnemyStats : EnemyStats
{
    public LayerMask raycastLayerMask;
    public float raycastCooldown;
}
