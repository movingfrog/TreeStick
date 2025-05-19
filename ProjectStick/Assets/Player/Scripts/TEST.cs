using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    Rigidbody2D rigid;
    int i = 1;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            i *= -1;
        }
        rigid.velocity = new Vector2(i * 5, rigid.velocity.y);
    }
}
