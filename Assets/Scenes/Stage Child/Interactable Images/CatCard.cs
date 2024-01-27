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
            if (this.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                rb.AddForce(Vector2.up * 100, ForceMode2D.Impulse);
            }

            rb.gravityScale = 5;
            if (this.TryGetComponent<Collider2D>(out Collider2D collider))
            {
                collider.isTrigger = true;
            }
        }

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(m_pushForce, ForceMode2D.Impulse);
        }
    }

}
