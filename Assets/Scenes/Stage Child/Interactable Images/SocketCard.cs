using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketCard : InteractableCard
{
    public override void OnCardInteract()
    {
        Debug.Log(this.name + "Interact");
    }


}
