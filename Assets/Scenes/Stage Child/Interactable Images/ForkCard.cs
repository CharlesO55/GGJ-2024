using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ForkCard : InteractableCard
{
    [SerializeField] Vector3 m_offset;
    [SerializeField] float m_rescale;

    public override void OnCardInteract(GameObject sender)
    {
        base.OnCardInteract(sender);

        this.transform.parent = sender.transform;

        this.transform.position += m_offset;
        this.transform.localScale = Vector3.one * m_rescale;
    }
}
