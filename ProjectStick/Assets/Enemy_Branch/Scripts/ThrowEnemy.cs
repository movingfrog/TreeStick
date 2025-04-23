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
                // 공격 중이 아닐 때만 보는 방향을 이동 방향과 같게 설정(디자인이 나오면 채울 부분)



                direction.x = direction.x > 0 ? -1 : direction.x < 0 ? 1 : 0; // 플레이어로부터 도망
                direction.y = 0;
                rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
                if (IsRayCasting(transform.position, direction, 3f, ground) && canJump) // 벽을 만나고 점프가 가능한 상황이라면 점프
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


        // 공격할 방향을 바라보게 설정(디자인이 나오면 채울 부분)




        Rigidbody2D material;
        Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
        material.AddForce(new Vector2(Direction * Distance, 4.9f + (direction.y * 4.9f)), ForceMode2D.Impulse); // 물리 계산 하기
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
        if (collision.gameObject.layer == Mathf.Log(ground.value, 2) && collision.contacts[0].normal.y > 0.7f)
        {
            canJump = true;
        }
    }
}
