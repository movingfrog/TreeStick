using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPosSetting : MonoBehaviour
{
    public Vector3 pos;

  void FixedUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(pos);
    }

    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(pos);
    }

    void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
