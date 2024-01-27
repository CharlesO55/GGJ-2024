using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0,-moveSpeed) - rb.velocity, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<OldManController>().Kill();
        }
        else if (col.CompareTag("Car"))
        {
            col.GetComponent<Car>().IncreaseSpeed();    
        }
        
    }

    public void IncreaseSpeed()
    {
        rb.AddForce(new Vector2(0,-moveSpeed - 300) - rb.velocity, ForceMode2D.Impulse);
    }
}
