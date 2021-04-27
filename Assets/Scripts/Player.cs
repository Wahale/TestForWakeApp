using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ISetPosition setPosition = new SetPosition();

    [SerializeField] private float speed;

    private Vector2 target;
    private bool canTakeDamage = true, canTakeScore = true;

    public static int Health = 3, Score,Record;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = new Vector2(setPosition.SetPointForPlayer().x, setPosition.SetPointForPlayer().y);
            BaseLogic.LookAtPoint(transform,target);
        }

        if (target != default)
            BaseLogic.ChangePointToMove(transform,ref target,default);
    }

    private void FixedUpdate()
    {
        if (target != default)
            BaseLogic.MoveToPoint(transform, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")&&canTakeDamage)
        {
            Health--;
            canTakeDamage = false;
        }
        if (collision.CompareTag("Score")&&canTakeScore)
        {
            Score++;
            collision.transform.position = setPosition.SetRandomPointInCircle(new Vector3(0,0,0));
            canTakeScore = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            canTakeDamage = true;
        if (collision.CompareTag("Score"))
            canTakeScore = true;
    }

    public static int SetRecord() => Score > Record ? Record = Score : Record;
}
