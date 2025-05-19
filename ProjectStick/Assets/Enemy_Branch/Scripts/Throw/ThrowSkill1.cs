using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkill1 : MonoBehaviour, IThrowSkill
{
    public int throwCount = 5;
    public float throwForce = 10;
    [SerializeField] GameObject throwMaterial;
    Vector2 direction;
    int Direction
    {
        get
        {
            return direction.x > 0 ? 1 : direction.x < 0 ? -1 : 0;
        }
    }

    public void Attack(Transform target = null)
    {
        if (target != null) direction = (target.position - transform.position).normalized;
        else direction = new Vector2(transform.localScale.x, 0);
        for (int i = 1; i <= throwCount; i++)
        {
            Rigidbody2D material;
            Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
            Vector2 direction = new Vector2(Mathf.Cos((i / (float)throwCount) * 90 * Mathf.Deg2Rad), Mathf.Sin((i / (float)throwCount) * 90 * Mathf.Deg2Rad)).normalized;
            material.AddForce(new Vector2(throwForce * Direction * direction.x, direction.y * throwForce), ForceMode2D.Impulse);
        }
    }
}
