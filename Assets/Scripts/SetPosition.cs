using UnityEngine;

public sealed class SetPosition : ISetPosition
{
    public Vector3 SetPointForPlayer()=> Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
    public Vector3 SetRandomPointInCircle(Vector3 center, float radius = 3)=> center + (Vector3)(radius * UnityEngine.Random.insideUnitCircle);
}

interface ISetPosition
{
    public Vector3 SetPointForPlayer();
    public Vector3 SetRandomPointInCircle(Vector3 center, float radius = 3);
}
