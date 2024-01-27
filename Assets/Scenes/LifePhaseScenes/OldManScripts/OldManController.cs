using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform movePoint;
    [SerializeField] private float step = 100f;

    [SerializeField] private LayerMask obstacleLayerMask;
    private void Start()
    {
        movePoint.parent = null;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                                                    movePoint.position, 
                                            moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * step, .2f, obstacleLayerMask))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * 100;
                }
            }
            else
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * step, .2f, obstacleLayerMask))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * 100;
                }
            }
        }
        
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
