using Cinemachine;
using UnityEngine;

public class Armstrong : DateCharacter
{
    private Animator m_Animator;
    [SerializeField] private float m_targetScale = 1;

    [SerializeField] private CinemachineVirtualCamera m_cam;


    void Awake()
    {
        this.m_Animator = GetComponent<Animator>();
        this.m_audioPlayer = GetComponent<AudioSource>();

    }

    void Update()
    {
        base.UpdatePlayProgress();
        base.CheckAudioPlaying();

        //Debug.Log(m_playbackRate);

        m_Animator.SetBool("IsEnding",  this.m_Dialogue.length - this.m_playbackTime < 0.8f);

        this.m_audioPlayer.volume = Mathf.Clamp(this.m_playbackRate, 0, 0.5f);
        this.transform.localScale = Vector3.one * m_targetScale * (m_playbackRate);

        Vector3 pos = this.transform.position;
        pos.z = -10 * m_playbackRate;


        /*if (this.m_playbackRate > 0.75f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, 
                Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -10)),
                    Time.deltaTime
                );
        }*/
        if (this.m_playbackRate > 0.99f)
        {
            this.GetComponent<ResultsTrigger>().ActivateResultsTrigger();
        }
        else if (this.m_playbackRate > .9f)
        {
            this.m_cam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
            this.m_cam.m_Follow = this.transform;
        }
    }
}
