using UnityEngine;

public class InputMovement : IMovementStrategy
{
    public virtual void Move(CharacterBase character, Vector3 position)
    {
        Debug.Log("InputMovement => " + character.name + " is moving to position " + position);
    }
}