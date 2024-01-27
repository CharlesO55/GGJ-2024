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

    void Start()
    {
        this.m_audioPlayer = this.GetComponent<AudioSource>();
        this.m_audioPlayer.clip = m_Dialogue;

        this.m_spriteRenderer = this.GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        if(m_spriteRenderer.isVisible)

        {
            Debug.Log("Visible: ");
        }
    }
}
