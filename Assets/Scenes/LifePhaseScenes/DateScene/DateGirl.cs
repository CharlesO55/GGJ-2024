using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DateGirl : DateCharacter
{
    [SerializeField] private UIDocument progressUI;
    private ProgressBar m_bar;

    [SerializeField] List<Sprite> m_spriteSwaps = new List<Sprite>();

    private bool m_isAngry = false;
    public float m_TotalTimePassed = 0;
    
    void Start()
    {
        this.Init();

        this.m_bar = progressUI.rootVisualElement.Q<ProgressBar>();
    }

    void Update()
    {
        this.UpdatePlayProgress();
        this.CheckAudioPlaying();

        this.m_bar.value = 1- this.m_playbackRate;

        m_TotalTimePassed += Time.deltaTime;
        if (this.m_playbackRate >= .98f)
        {
            this.GetComponent<ResultsTrigger>().ActivateResultsTrigger();
        }

        if (!this.m_isAngry && m_TotalTimePassed > 20 && this.m_playbackRate < 50)
        {
            this.m_spriteRenderer.sprite = this.m_spriteSwaps[1];
            this.m_isAngry = true;
        }
        else if (this.m_spriteRenderer.isVisible && m_isAngry)
        {
            m_spriteRenderer.sprite = this.m_spriteSwaps[0];
            m_isAngry = false;
        }
        
    }

    protected override void StopAudio()
    {
        //Date Charcter's
        Debug.Log("Stop");

        this.m_Child.SetActive(false);

        this.m_audioPlayer.Stop();

        
        this.m_spriteRenderer.sprite = this.m_spriteSwaps[1];

        this.m_isAngry = true;
    }
}
