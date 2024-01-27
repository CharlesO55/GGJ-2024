using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class DateCharacter : MonoBehaviour
{
    [SerializeField] protected AudioClip m_Dialogue;
    protected AudioSource m_audioPlayer;

    [SerializeField] protected float m_playbackTime = 0f;

    protected float m_playbackRate = 0f;

    protected SpriteRenderer m_spriteRenderer;

    [SerializeField] protected GameObject m_Child;

    void Start()
    {
        this.Init();
    }

    protected void Init()
    {
        this.m_audioPlayer = this.GetComponent<AudioSource>();
        this.m_audioPlayer.clip = m_Dialogue;

        this.m_spriteRenderer = this.GetComponent<SpriteRenderer>();


        this.m_Child = this.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        this.UpdatePlayProgress();
        this.CheckAudioPlaying();
    }

    protected void UpdatePlayProgress()
    {
        if (m_audioPlayer.isPlaying)
        {
            this.m_playbackTime = this.m_audioPlayer.time + 0.1f;

            this.m_playbackRate = m_playbackTime / m_Dialogue.length;

            if (this.m_playbackTime >= this.m_Dialogue.length)
            {
                Debug.Log("Completed audio" + m_Dialogue.name);
            }
        }
    }

    protected void CheckAudioPlaying()
    {
        if (m_spriteRenderer.isVisible && !this.m_audioPlayer.isPlaying)
        {
            this.StartAudio();
        }

        else if (!m_spriteRenderer.isVisible && this.m_Child.activeInHierarchy)
        {
            this.StopAudio();
        }
    }

    protected virtual void StartAudio()
    {
        Debug.Log("Start");
        this.m_Child.SetActive(true);


        
        this.m_audioPlayer.time = Mathf.Clamp(this.m_playbackTime, 0, m_Dialogue.length);
        this.m_audioPlayer.Play();
    }

    protected virtual void StopAudio()
    {
        Debug.Log("Stop");

        this.m_Child.SetActive(false);

        this.m_audioPlayer.Stop();
    }
}
