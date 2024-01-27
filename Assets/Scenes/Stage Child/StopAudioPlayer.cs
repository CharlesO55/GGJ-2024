using UnityEngine;

public class StopAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioPlayer;
    void OnTriggerEnter2D(Collider2D collision)
    {
        m_audioPlayer.Stop();
        m_audioPlayer.clip = null;
    }
}
