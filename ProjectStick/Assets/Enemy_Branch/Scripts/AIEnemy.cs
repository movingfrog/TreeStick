using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIEnemy : Enemy
{
    public int moveSpeed = 5;
    public float noticeRange = 10;
    protected LayerMask ground;
    protected LayerMask player;
    protected Transform target;

    protected override void Awake()
    {
        base.Awake();
        ground = LayerMask.GetMask("Ground");
        player = LayerMask.GetMask("Player");
        target = FindObjectOfType<PlayerController>().transform;
    }

    protected bool IsRayCasting(Vector2 center, Vector2 direction, float range, LayerMask layer)
    {
        return Physics2D.Raycast(center, direction, range, layer).collider != null;
    }

    protected abstract void Attack();
    protected abstract void Jump();
}
