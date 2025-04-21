using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float Speed;

    Rigidbody2D rigid;
    Vector2 moveDirection;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isControl = (moveDirection != Vector2.zero);

        if (isControl)
        {
            rigid.velocity += moveDirection * Speed;
        }
        else
        {
            rigid.velocity = Vector2.up * rigid.velocity.y;
        }
    }

    void OnMove()
    {

    }
}
