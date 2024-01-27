using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class DateCharacter : MonoBehaviour
{
    [SerializeField] AudioClip m_Dialogue;
    private AudioSource m_audioPlayer;

    [SerializeField] private float m_playbackTime = 0f;


    SpriteRenderer m_spriteRenderer;

    [SerializeField] private GameObject m_Child;

    void Start()
    {
        this.m_audioPlayer = this.GetComponent<AudioSource>();
        this.m_audioPlayer.clip = m_Dialogue;

        this.m_spriteRenderer = this.GetComponent<SpriteRenderer>();


        this.m_Child = this.transform.GetChild(0).gameObject;
    }


    void Update()
    {
        if (m_audioPlayer.isPlaying)
        {
            this.m_playbackTime = this.m_audioPlayer.time + 1;
            if (this.m_playbackTime >= this.m_Dialogue.length)
            {
                Debug.Log("Completed audio" + m_Dialogue.name);
            }
        }

        if (m_spriteRenderer.isVisible && !this.m_audioPlayer.isPlaying)
        {
            Debug.Log("Start");

            this.m_Child.SetActive(true);

            this.m_audioPlayer.time = this.m_playbackTime - 1;
            this.m_audioPlayer.Play();
        }

        else if (!m_spriteRenderer.isVisible && this.m_Child.activeInHierarchy)
        {
            Debug.Log("Stop");

            this.m_Child.SetActive(false);

            this.m_audioPlayer.Stop();
        }
    }
}
