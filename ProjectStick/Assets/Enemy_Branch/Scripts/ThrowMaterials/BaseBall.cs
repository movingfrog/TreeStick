using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBall : ThrowMaterialParent
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            targetDamage.GetDamage(boomDamage);
        }
        base.OnCollisionEnter2D(collision);
    }

    protected override void OnDestroy()
    {
        // 사라지는 이펙트만
    }
}
