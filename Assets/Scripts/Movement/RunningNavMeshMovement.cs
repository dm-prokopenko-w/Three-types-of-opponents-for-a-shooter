public class RunningNavMeshMovement : NavMeshMovement
{
    public virtual void Move(CharacterBase character, UnityEngine.Vector3 position)
    {
        UnityEngine.Debug.Log("RunningNavMeshMovement => " + character.name + " is moving");
    }
}