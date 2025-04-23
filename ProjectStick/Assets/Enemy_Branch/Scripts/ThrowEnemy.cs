using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowEnemy : AIEnemy
{
    [SerializeField] float throwForce = 8;
    [SerializeField] GameObject throwMaterial;
    bool canMove = true;
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

    private void FixedUpdate()
    {
        direction = (target.position - transform.position).normalized;
        if (Distance <= noticeRange * 3)
        {
            if (Distance <= noticeRange && canAttack)
            {
                Attack();
            }
            if (canMove)
            {
                direction.x = direction.x > 0 ? -1 : direction.x < 0 ? 1 : 0; // 플레이어로부터 도망
                direction.y = 0;
                rb.velocity = direction * moveSpeed;
                if (IsRayCasting(transform.position, direction, 3f, ground) && canJump) // 벽을 만나고 점프가 가능한 상황이라면 점프
                {
                    Jump();
                }
            }
        }
    }

    protected override void Attack()
    {
        rb.velocity = Vector2.zero;
        canAttack = false;
        canMove = false;
        Rigidbody2D material;
        Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
        material.AddForce(direction * throwForce + new Vector2(0, Distance / 2f), ForceMode2D.Impulse);
        StartCoroutine(WaitAction.wait(attackSpeedSeconds / 2f, () =>
        {
            canMove = true;
        }));
        StartCoroutine(WaitAction.wait(attackSpeedSeconds, () =>
        {
            canAttack = true;
        }));
    }

    protected override void Jump()
    {
        canJump = false;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        //점프 애니메이션
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == ground && collision.contacts[0].normal.y > 0.7f)
        {
            canJump = true;
        }
    }
}
