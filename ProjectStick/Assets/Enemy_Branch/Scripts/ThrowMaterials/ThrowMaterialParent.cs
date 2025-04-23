using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrowMaterialParent : MonoBehaviour
{
    public float attackAmount;
    public float boomDamage;
    public float boomRange;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    protected abstract void OnDestroy();
}
