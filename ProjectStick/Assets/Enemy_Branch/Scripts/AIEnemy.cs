using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIEnemy : Enemy
{
    public int moveSpeed = 5;
    public float noticeRange = 10;
    protected LayerMask ground;
    protected LayerMask player;
    protected Rigidbody2D rb;
    protected Transform target;
    protected Animator anim;

    protected virtual void Awake()
    {
        ground = LayerMask.GetMask("Ground");
        player = LayerMask.GetMask("Player");
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>().transform;
        TryGetComponent<Animator>(out anim);
    }

    protected bool IsRayCasting(Vector2 center, Vector2 direction, float range, LayerMask layer)
    {
        return Physics2D.Raycast(center, direction, range, layer).collider != null;
    }

    protected abstract void Attack();
    protected abstract void Jump();
}
