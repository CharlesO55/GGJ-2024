using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSwappableCharacter : DateCharacter
{
    private int m_spriteSwapIndex = 0;
    [SerializeField] protected List<Sprite> m_spriteSwaps = new List<Sprite>();
    [SerializeField] private List<float> m_progressTimes = new List<float>();


    void Update()
    {
        this.UpdatePlayProgress();
        this.CheckAudioPlaying();


        this.SwapSprites();
    }


    protected override void StartAudio()
    {
        base.StartAudio();

        this.m_spriteRenderer.sprite = m_spriteSwaps[0];
    }

    protected override void StopAudio()
    {
        base.StopAudio();

        this.m_spriteSwapIndex = 0;
    }

    void SwapSprites()
    {

        if (this.m_playbackTime >= this.m_progressTimes[this.m_spriteSwapIndex])
        {
            if (m_spriteSwapIndex < m_spriteSwaps.Count)
            {
                m_spriteSwapIndex++;
                Debug.Log("Swapped sprite: " + m_spriteSwapIndex);

                this.m_spriteRenderer.sprite = m_spriteSwaps[m_spriteSwapIndex];
            }
        }



        /*if (this.m_spriteSwapIndex < this.m_spriteSwaps.Count && this.m_playbackTime >= this.m_progressTimes[this.m_spriteSwapIndex])
        {
            this.m_spriteSwapIndex++;

            if (m_spriteSwapIndex < this.m_spriteSwaps.Count)
            {
                this.m_spriteRenderer.sprite = m_spriteSwaps[this.m_spriteSwapIndex];
            }
        }*/
    }
}
