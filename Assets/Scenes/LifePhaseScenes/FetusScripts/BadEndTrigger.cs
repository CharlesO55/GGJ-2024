using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndTrigger : ResultsTrigger
{
    private float _spacePressTime = 0f;
    [SerializeField] private float _maxPressTimer = 5;

    /*void Start()
    {
        FetusSpaceScript.OnInputFailed += CheckFailTimer;
    }
*/
    void CheckFailTimer(/*object sender, EventArgs evt*/)
    {
        _spacePressTime += Time.deltaTime * 2;

        if (_spacePressTime > _maxPressTimer)
        {
            this.ActivateResultsTrigger();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.CheckFailTimer();
        }
        else
        {
            this._spacePressTime -= Time.deltaTime;
        }
    }

}
