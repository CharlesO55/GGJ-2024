using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OldMansfx : MonoBehaviour
{


    [SerializeField] List<AudioClip> m_AudioClipList = new();
    List<AudioSource> m_AudioSources = new();

    void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            this.m_AudioSources.Add(this.AddComponent<AudioSource>());
        }

        foreach (AudioSource src in m_AudioSources)
        {
            src.volume = 0.3f;
            src.playOnAwake = false;
        }
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Car"))
        {
            foreach (AudioSource src in m_AudioSources)
            {
                if (!src.isPlaying)
                {
                    int rng = Random.Range(0, m_AudioClipList.Count);

                    src.PlayOneShot(this.m_AudioClipList[rng]);

                    SpriteSpawner.Instance.m_StartShowingSprites = true;
                    Time.timeScale = 1;
                    break;
                }
            }
        }
    }
}