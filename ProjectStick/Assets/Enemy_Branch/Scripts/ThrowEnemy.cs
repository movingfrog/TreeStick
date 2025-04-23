using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowEnemy : AIEnemy
{
    [SerializeField] GameObject throwMaterial;
    bool canMove = false;
    bool canAttack = true;
    bool canJump = false;
    [SerializeField] float attackSpeedSeconds = 1.5f;
    [SerializeField] float jumpForce = 10f;
    float Distance
    {
        get
        {
            return Vector2.Distance(target.position, transform.position);
        }
    }
    Vector2 direction;
    int Direction
    {
        get
        {
            return direction.x > 0 ? 1 : direction.x < 0 ? -1 : 0;
        }
    }

    private void FixedUpdate()
    {
        direction = (target.position - transform.position).normalized;
        if (Distance <= noticeRange)
        {
            if (canAttack)
            {
                Attack();
                canMove = true;
            }
            if (canMove)
            {
                // ���� ���� �ƴ� ���� ���� ������ �̵� ����� ���� ����(�������� ������ ä�� �κ�)



                direction.x = direction.x > 0 ? -1 : direction.x < 0 ? 1 : 0; // �÷��̾�κ��� ����
                direction.y = 0;
                rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
                if (IsRayCasting(transform.position, direction, 3f, ground) && canJump) // ���� ������ ������ ������ ��Ȳ�̶�� ����
                {
                    Jump();
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            canMove = false;
        }
    }

    protected override void Attack()
    {
        canAttack = false;


        // ������ ������ �ٶ󺸰� ����(�������� ������ ä�� �κ�)




        Rigidbody2D material;
        Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
        material.AddForce(new Vector2(Direction * Distance, 4.9f + (direction.y * 4.9f)), ForceMode2D.Impulse); // ���� ��� �ϱ�
        StartCoroutine(WaitAction.wait(attackSpeedSeconds, () =>
        {
            canAttack = true;
        }));
    }

    protected override void Jump()
    {
        canJump = false;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        //���� �ִϸ��̼�
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(ground.value, 2) && collision.contacts[0].normal.y > 0.7f)
        {
            canJump = true;
        }
    }
}
