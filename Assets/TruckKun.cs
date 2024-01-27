using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckKun : MonoBehaviour
{
    private float timer = 3f;
    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (timer < 0)
        {
            if (this.TryGetComponent<ResultsTrigger>(out var res))
            {
                res.ActivateResultsTrigger();
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
