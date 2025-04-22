using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemyDamage
{
    public int Hp = 100;
    public int attackAmount = 10;
    public enum EnemyKind
    {
        Normal = 0,
        Boss = 1
    }
    public EnemyKind Kind;

    public virtual void Damage(float damage)
    {
    }

    public virtual void Death()
    {
    }
}
