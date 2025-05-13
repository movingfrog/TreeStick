using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkill1 : MonoBehaviour, IThrowSkill
{
    public int throwCount = 5;
    public float throwForce = 5;
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
        direction = (target.position - transform.position).normalized;
        for (int i = 1; i <= throwCount; i++)
        {
            Rigidbody2D material;
            Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
            material.AddForce(new Vector2(throwForce * Direction / i, i * throwForce), ForceMode2D.Impulse);
        }
    }
}
