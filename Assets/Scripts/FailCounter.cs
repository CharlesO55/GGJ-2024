using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailCounter : MonoBehaviour
{
    [SerializeField] int m_failedTimes = 0;
    [SerializeField] private float m_reduceEverySeconds = 2;
    float m_Timer = 0f;

    [SerializeField] private int m_maxFailTimes;
    void Start()
    {
        FetusSpaceScript.OnInputFailed += Counter;
    }

    void OnDestroy()
    {
        FetusSpaceScript.OnInputFailed -= Counter;
    }
    /*void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_failedTimes++;
            Debug.Log("Space pressed" +
                      m_failedTimes);
        }
    }*/

    void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer > m_reduceEverySeconds)
        {
            m_Timer = 0f;

            if (m_failedTimes > 0)
            {
                m_failedTimes--;
            }
        }
    }

    void Counter(object sender, EventArgs e)
    {
        this.m_failedTimes++;
        Debug.Log("FAILED TIMES: " + this.m_failedTimes);

        if (m_failedTimes >= m_maxFailTimes)
        {
            this.GetComponent<ResultsTrigger>().ActivateResultsTrigger();
        }
    }
}
