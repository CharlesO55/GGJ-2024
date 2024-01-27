using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatCard : InteractableCard
{
    [SerializeField] private Vector2 m_pushForce;

    public override void OnCardInteract(GameObject sender)
    {
        base.OnCardInteract(sender);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
     
        Debug.Log(other.gameObject.name);
        if (other.gameObject.GetComponent<ForkCard>() != null)
        {
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(m_pushForce, ForceMode2D.Impulse);
        }
    }

}
