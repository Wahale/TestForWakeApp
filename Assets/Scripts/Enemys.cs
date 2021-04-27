using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    ISetPosition setPosition = new SetPosition();

    [SerializeField] private float speed;
    [SerializeField] private Transform center;

    private Vector2 target;

    private void Start()=> target = setPosition.SetRandomPointInCircle(center.position);

    private void Update()
    {
        BaseLogic.ChangePointToMove(transform,ref target, setPosition.SetRandomPointInCircle(center.position));
        BaseLogic.LookAtPoint(transform,target);
    }

    private void FixedUpdate() => BaseLogic.MoveToPoint(transform, speed);
}
