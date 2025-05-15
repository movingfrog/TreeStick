using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemyDamage
{
    public float Hp = 100;
    public float attackAmount = 10;
    protected Animator anim;
    protected Rigidbody2D rb;
    public enum EnemyKind
    {
        Normal = 0,
        Boss = 1
    }
    public EnemyKind Kind;
    protected bool isStuned = false;

    protected virtual void Awake()
    {
        TryGetComponent<Animator>(out anim);
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Damage(float damage, Vector2 mainAgentPos, Vector2 knockBackForce = new Vector2(), float stunTime = 0.5f)
    {
        if (!isStuned)
        {
            isStuned = true;
            Hp -= damage;
            float direction = mainAgentPos != null ? Mathf.Sign(mainAgentPos.x - transform.position.x) : 0;
            rb.AddForce(new Vector2(knockBackForce.x * direction, knockBackForce.y), ForceMode2D.Impulse);
            float temp = anim.speed;
            anim.speed = 0;
            StartCoroutine(WaitAction.wait(stunTime, () =>
            {
                isStuned = false;
                anim.speed = temp;
            }));
        }
    }

    public virtual void Death()
    {
    }
}
