using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementStrategy 
{
    void Move(CharacterBase character, Vector3 position);
}
