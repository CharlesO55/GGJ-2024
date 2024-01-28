using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipObject : MonoBehaviour
{
    [SerializeField] private Transform Object;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Object.localScale = new Vector3(-1, 1, 1);
        }
    }
}
