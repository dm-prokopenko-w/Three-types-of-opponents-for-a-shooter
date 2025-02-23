using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : IMovementStrategy
{
    public virtual void Move(CharacterBase character, Vector3 position)
    {
        Debug.Log("NavMeshMovement => " + character.name + " is moving");
        if (character is EnemyBase enemyBase)
        {
            if (enemyBase.EnemyNavMeshAgent != null)
            {
                enemyBase.EnemyNavMeshAgent.SetDestination(position);
            }
        }
    }
}
