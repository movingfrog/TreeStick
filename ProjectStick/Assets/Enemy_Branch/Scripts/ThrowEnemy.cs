using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEnemy : AIEnemy
{
    [SerializeField] float throwForce = 8;
    [SerializeField] GameObject throwMaterial;
    bool canMove = true;
    bool canAttack = true;
    int Direction
    {
        get
        {
            return transform.rotation.eulerAngles.y == 0 ? -1 : 1;
        }
    }
    [SerializeField] float attackSpeedSeconds = 1.5f;

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        Vector2 direction = (target.position - transform.position).normalized;
        if (distance <= noticeRange && canAttack)
        {
            rb.velocity = Vector2.zero;
            canAttack = false;
            canMove = false;
            Rigidbody2D material;
            Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
            material.AddForce(direction * throwForce + new Vector2(0, distance / 2f), ForceMode2D.Impulse);
            StartCoroutine(WaitAction.wait(attackSpeedSeconds / 2f, () =>
            {
                canMove = true;
            }));
            StartCoroutine(WaitAction.wait(attackSpeedSeconds, () =>
            {
                canAttack = true;
            }));
        }
        else if (canMove)
        {
            direction.x = direction.x > 0 ? -1 : direction.x < 0 ? 1 : 0; // 플레이어 반대 방향으로 도망
            direction.y = 0;
            rb.velocity = direction * moveSpeed;
            // 내일 할 일 : 적 점프 하기
        }
    }
}
