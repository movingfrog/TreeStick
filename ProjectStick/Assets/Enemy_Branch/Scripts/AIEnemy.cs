using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : Enemy
{
    public int moveSpeed;
    public float noticeRange;
    protected LayerMask ground;
    protected LayerMask player;

    protected virtual void Awake()
    {
        ground = LayerMask.GetMask("Ground");
        player = LayerMask.GetMask("Player");
    }

    protected bool IsRayCasting(Vector2 center, Vector2 direction, float range, LayerMask layer)
    {
        return Physics2D.Raycast(center, direction, range, layer);
    }
}
