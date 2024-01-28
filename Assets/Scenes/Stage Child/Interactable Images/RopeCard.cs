using BukoClimbers;
using Cinemachine;
using UnityEngine;

public class RopeCard : InteractableCard
{
    [SerializeField] private Vector2 m_roofLoc;

    [SerializeField] AudioClip m_audioClip;
    [SerializeField] private AudioSource m_audioPlayer;

    //[SerializeField] private CinemachineVirtualCamera roofVC;

    public override void OnCardInteract(GameObject sender)
    {
        base.OnCardInteract(sender);
       //CameraSwitcher.SwitchCamera(roofVC);
        Vector3 currPos = sender.transform.position;
        

        sender.transform.position = new Vector3(m_roofLoc.x, m_roofLoc.y, currPos.z);
        
        m_audioPlayer.clip = m_audioClip;
        m_audioPlayer.Play();
    }
}
