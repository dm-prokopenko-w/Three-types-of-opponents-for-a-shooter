using UnityEngine;

public class DefaultMovement: IMovementStrategy
{
    public virtual void Move(CharacterBase character, Vector3 position)
    {
        Debug.Log("DefaultMovement => " + character.name + " is moving");
    }
}