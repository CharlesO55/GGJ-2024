using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChiyoScript : DateCharacter
{
    [SerializeField] private float m_speed = 1;
    [SerializeField] private float m_limit = 15;
    void Start()
    {
        base.Init();
    }
    void Update()
    {
        base.UpdatePlayProgress();
        base.CheckAudioPlaying();

        if (m_audioPlayer.isPlaying && this.m_playbackRate > 0 && this.m_playbackRate < m_limit)
        {
            this.transform.position += Vector3.down * m_speed * Time.deltaTime;
        }
    }
}
