using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrowMaterialParent : MonoBehaviour
{
    public float attackAmount;
    public float boomDamage;
    public float boomRange;
    public float stayTime = 10f;

    private void Start()
    {
        Destroy(gameObject, stayTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    protected abstract void OnDestroy();
}
