using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ThrowSkill2 : MonoBehaviour, IThrowSkill
{
    Transform target;
    [SerializeField] GameObject throwMaterial;
    public float followTime = 3f;
    public Vector2 throwForce = new Vector2(5, 5);
    Vector2 Direction
    {
        get
        {
            return (target.position - transform.position).normalized;
        }
    }

    void Awake()
    {
        target = FindObjectOfType<PlayerController>().transform;
        Debug.Log(target.position);
    }

    public void Attack()
    {
        Rigidbody2D material;
        Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
        material.AddForce(new Vector2(throwForce.x * Mathf.Sign(Direction.x), throwForce.y), ForceMode2D.Impulse);
        StartCoroutine(WaitAction.wait(() => { return material.velocity.y < 0; }, () =>
        {
            StartCoroutine(follow(material));
        }));
    }

    IEnumerator follow(Rigidbody2D material)
    {
        float temp = followTime;
        material.gravityScale = 0;
        material.velocity = Vector2.zero;
        while (temp > 0)
        {
            if (material == null) break;
            Vector2 direction = (target.position - material.transform.position).normalized;
            material.AddForce(direction * throwForce.magnitude * Time.deltaTime * 2, ForceMode2D.Impulse);
            temp -= Time.deltaTime;
            yield return null;
        }
    }
}
