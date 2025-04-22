using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemyDamage
{
    public int Hp;
    public int attackAmount;

    public virtual void Damage(float damage)
    {
    }

    public virtual void Death()
    {
    }
}
