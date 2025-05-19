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

    public void Attack(Transform target = null)
    {
        this.target = target;
        if (target != null)
        {
            Rigidbody2D material;
            Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
            material.AddForce(new Vector2(throwForce.x * Mathf.Sign(Direction.x), throwForce.y), ForceMode2D.Impulse);
            StartCoroutine(WaitAction.wait(() => { return material.velocity.y < 0; }, () =>
            {
                StartCoroutine(follow(material));
            }));
        }
        else
        {
            float direction = transform.localScale.x;
            Rigidbody2D material;
            Instantiate(throwMaterial, transform.position, Quaternion.identity).TryGetComponent<Rigidbody2D>(out material);
            material.AddForce(new Vector2(throwForce.x * direction, throwForce.y), ForceMode2D.Impulse);
            StartCoroutine(WaitAction.wait(() => { return material.velocity.y < 0; }, () =>
            {
                StartCoroutine(follow(material));
            }));
        }
    }

    IEnumerator follow(Rigidbody2D material)
    {
        if (target != null)
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
        else
        {
            Enemy[] enemys = FindObjectsOfType<Enemy>();
            List<Transform> targets = new List<Transform>();
            float temp = followTime;
            material.gravityScale = 0;
            material.velocity = Vector2.zero;
            while (temp > 0)
            {
                if (material == null) break;

                targets.Clear();
                // 살아있는 적들의 Transform을 리스트에 추가
                for (int i = 0; i < enemys.Length; i++)
                {
                    if (enemys[i] == null)
                    {
                        continue;
                    }
                    targets.Add(enemys[i].transform);
                }

                Vector2 position = material.transform.position;
                target = targets.Count > 0 ? targets[0] : null;
                // 살아있는 적 중 가장 가까운 적을 target에 대입
                for (int i = 1; i < targets.Count; i++)
                {
                    if (targets[i] != null)
                    {
                        if (Vector2.Distance(position, targets[i].position) < Vector2.Distance(position, target.position))
                        {
                            target = targets[i];
                        }
                    }
                }
                Vector2 direction = (target.position - material.transform.position).normalized;
                material.AddForce(direction * throwForce.magnitude * Time.deltaTime * 2, ForceMode2D.Impulse);
                temp -= Time.deltaTime;
                yield return null;
            }
        }
    }
}
