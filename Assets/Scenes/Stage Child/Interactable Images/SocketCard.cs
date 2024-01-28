using UnityEngine;

public class SocketCard : InteractableCard
{
    [SerializeField] private Sprite deathSprite;
    [SerializeField] private ChildDeathHandler deathHandler;
    public override void OnCardInteract(GameObject sender)
    {
        base.OnCardInteract(sender);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.GetComponent<ForkCard>() != null)
        {
            if (this.TryGetComponent<ResultsTrigger>(out ResultsTrigger results))
            {
                results.ActivateResultsTrigger();
            }
            deathHandler.HandleDeath(deathSprite);
            
        }
    }
}