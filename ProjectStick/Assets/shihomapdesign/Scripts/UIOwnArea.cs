using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIOwnArea : MonoBehaviour
{
    public GameObject UI;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            UI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }
}