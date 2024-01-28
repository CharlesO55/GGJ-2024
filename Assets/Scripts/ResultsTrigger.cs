using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class ResultsTrigger : MonoBehaviour
{
    [SerializeField] private Texture m_image;
    [SerializeField] private string m_title;
    [SerializeField] private string m_description;

    [Description("True for fail result screens.")]
    [SerializeField] bool m_IsFailTrigger = true;

    [Header("Next scene if Pass/Success")]
    [SerializeField] private int m_nextSceneIndex;

    [SerializeField] private bool m_IsActivateOnTriggerEnter = false;


    [SerializeField] private AudioClip m_clipToPlayAtEnd;
    private AudioSource m_player;

    void Awake()
    {
        if (m_clipToPlayAtEnd != null)
        {
            m_player = GetComponent<AudioSource>();

            if (m_player == null)
            {
                m_player = this.AddComponent<AudioSource>();
                m_player.playOnAwake = false;
            }
        }
        
    }
    public void ActivateResultsTrigger()
    {
        if (this.m_player != null)
        {
            this.m_player.clip = this.m_clipToPlayAtEnd;
            this.m_player.Play();
        }

        if (m_IsFailTrigger)
        {
            ResultsScreenManager.Instance.ShowFailResult(m_title, m_description, m_image);
        }
        else
        {
            ResultsScreenManager.Instance.ShowPassResult(m_title, m_description, m_image, m_nextSceneIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.m_IsActivateOnTriggerEnter && other.CompareTag("Player"))
            this.ActivateResultsTrigger();
    }
}
