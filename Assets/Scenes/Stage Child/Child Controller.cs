using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChildController : MonoBehaviour
{

    private Rigidbody2D m_rb;

    private InteractableCard m_InteractableCard;

    [SerializeField] private float m_SpeedMultiplier;
    [SerializeField] Vector2 m_Move;

    void Start()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        m_Move = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetMouseButtonDown(0) && this.m_InteractableCard != null)
        {
            this.m_InteractableCard.OnCardInteract();
        }
    }

    void FixedUpdate()
    {
        if (m_Move.x != 0.0f)
        {
            //Debug.Log(m_Move.x);

            this.m_rb.velocity = this.m_Move * m_SpeedMultiplier * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("PlatformerInteractable"))
        {
            hit.gameObject.TryGetComponent<InteractableCard>(out this.m_InteractableCard);
            this.m_InteractableCard.HighlightCard(true);
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        this.m_InteractableCard.HighlightCard(false);
        this.m_InteractableCard = null;
    }
}
