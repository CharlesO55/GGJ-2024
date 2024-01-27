using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class RopeCard : InteractableCard
{
    [SerializeField] private Vector2 m_roofLoc;

    [SerializeField] AudioClip m_audioClip;


    public override void OnCardInteract(GameObject sender)
    {
        base.OnCardInteract(sender);

        Vector3 currPos = sender.transform.position;

        sender.transform.position = new Vector3(m_roofLoc.x, m_roofLoc.y, currPos.z);


         
    }


}
