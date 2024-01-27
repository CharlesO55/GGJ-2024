using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class FetusSpaceScript : MonoBehaviour
{
    public static event EventHandler OnInputSuccess;
    public static event EventHandler OnInputFailed;


    private bool isActive = true;
    private float timer;
    private float spaceTimer;
    private float spaceTimerMax;

    [SerializeField] private GameObject spaceIndicator;
    [SerializeField] private Image spaceIndicatorFill;
    
    [Serializable]
    private struct TimerBounds
    {
        public float min;
        public float max;
    }

    [SerializeField] private TimerBounds timerBounds;
    [SerializeField] private TimerBounds spaceTimerBounds;
    
    private void Awake()
    {
        InitializeTimer();
    }

    private void Start()
    {
        FetusSceneScript.OnPhaseEnd += FetusSceneScript_OnPhaseEnd;
    }

    private void FetusSceneScript_OnPhaseEnd(object sender, EventArgs e)
    {
        isActive = false;
        spaceIndicator.SetActive(false);
        
        if (this.TryGetComponent<ResultsTrigger>(out ResultsTrigger results))
        {
            results.ActivateResultsTrigger();
        }
    }

    private void Update()
    {
        if (!isActive) return;
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space)) 
                OnInputFailed?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            if (!spaceIndicator.activeSelf)
            {
                spaceIndicator.SetActive(true);
                InitializeSpaceTimer();
            }

            if (spaceTimer > 0)
            {
                spaceTimer -= Time.deltaTime;
                spaceIndicatorFill.fillAmount = Mathf.Abs((spaceTimer / spaceTimerMax)-1);
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    spaceIndicator.SetActive(false);
                    OnInputSuccess?.Invoke(this, EventArgs.Empty);
                    InitializeTimer();
                }
            }
            else
            {
                OnInputFailed?.Invoke(this, EventArgs.Empty);
                spaceIndicator.SetActive(false);
                InitializeTimer();
            }
        }
        
    }

    private void InitializeTimer()
    {
        timer = Random.Range(timerBounds.min, timerBounds.max);
    }

    private void InitializeSpaceTimer()
    {
        spaceTimer = Random.Range(spaceTimerBounds.min, spaceTimerBounds.max);
        spaceTimerMax = spaceTimer;
    }
}
