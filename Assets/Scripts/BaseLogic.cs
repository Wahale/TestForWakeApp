using System;
using UnityEngine;

public sealed class BaseLogic
{
    public static void MoveToPoint(Transform obj, float speed)=> obj.Translate(speed * Time.fixedDeltaTime, 0, 0);

    public static void LookAtPoint(Transform obj,Vector3 pos)
    {
        Vector3 target = obj.InverseTransformPoint(pos);
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        obj.Rotate(0, 0, angle);
    }

    public static void ChangePointToMove(Transform obj, ref Vector2 pos,Vector2 posToMove)
    {
        if (Math.Round(obj.position.x, 1) == Math.Round(pos.x, 1) && Math.Round(obj.position.y, 1) == Math.Round(pos.y, 1))
            pos = posToMove;
    }
}

