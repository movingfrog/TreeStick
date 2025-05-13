using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEnemy : AIEnemy
{
    [SerializeField] GameObject throwMaterial;
    bool canMove = false;
    bool canAttack = true;
    bool canJump = false;
    [SerializeField] float attackSpeedSeconds = 1.5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float throwAngle = 30;
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

    Vector2 DistanceEach
    {
        get
        {
            return target.position - transform.position;
        }
    }

    private float originalAngle;

    protected override void Awake()
    {
        base.Awake();
        originalAngle = throwAngle;
    }

    private void FixedUpdate()
    {
        direction = DistanceEach.normalized;
        if (Distance <= noticeRange)
        {
            if (canAttack)
            {
                canAttack = false;
                if (TryGetComponent<IThrowSkill>(out IThrowSkill skill))
                {
                    int random = Random.Range(0, 3);
                    Debug.Log("random : " + random);
                    if (random == 0)
                    {
                        skill.Attack();
                    }
                    else
                    {
                        Attack();
                    }
                }
                else
                {
                    Attack();
                }
                StartCoroutine(WaitAction.wait(attackSpeedSeconds, () =>
                {
                    canAttack = true;
                }));
                canMove = true;
            }
            if (canMove)
            {
                // ���� ���� �ƴ� ���� ���� ������ �̵� ����� ���� ����(�������� ������ ä�� �κ�)



                direction.x = -Mathf.Sign(direction.x); // �÷��̾�κ��� ����
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
        // ������ ������ �ٶ󺸰� ���� + ���� �ִϸ��̼�(�������� ������ ä�� �κ�)
        

        Rigidbody2D material;
        Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);

        float realAngle = Mathf.Atan2(DistanceEach.y, Mathf.Abs(DistanceEach.x)) * Mathf.Rad2Deg + (10 * Mathf.Sign(DistanceEach.y));

        throwAngle = realAngle <= originalAngle ? originalAngle : realAngle;

        float gravity = Mathf.Abs(Physics2D.gravity.y);

        float x = Mathf.Abs(DistanceEach.x);
        float y = DistanceEach.y;
        if (throwAngle < 90)
        {
            float radian = throwAngle * Mathf.Deg2Rad;

            float cos = Mathf.Cos(radian);
            float sin = Mathf.Sin(radian);
            float tan = Mathf.Tan(radian);

            float squareForce = (gravity * x * x) / (2 * (x * tan - y) * cos * cos);

            float force = Mathf.Sqrt(squareForce);

            Vector2 velocity = new Vector2(force * cos, force * sin);

            velocity.x *= Mathf.Sign(DistanceEach.x);

            material.AddForce(velocity, ForceMode2D.Impulse);
        }
        else
        {
            float force = Mathf.Sqrt(2 * Distance * gravity);

            material.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
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
