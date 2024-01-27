using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketCard : InteractableCard
{
    public override void OnCardInteract(GameObject sender)
    {
        base.OnCardInteract(sender);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.GetComponent<ForkCard>() != null)
        {
            Debug.LogWarning("DIED");
        }
    }
}