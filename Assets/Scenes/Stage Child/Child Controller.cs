using UnityEngine;

public class ChildController : MonoBehaviour
{

    private Rigidbody2D m_rb;

    private InteractableCard m_InteractableCard;

    [SerializeField] private float m_SpeedMultiplier;
    [SerializeField] Vector2 m_Move;

    [SerializeField] LayerMask m_FloorLayer;
    [SerializeField] private float m_RaycastFloorDistance = 0.5f;

    void Start()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        m_Move = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetMouseButtonDown(0) && this.m_InteractableCard != null)
        {
            this.m_InteractableCard.OnCardInteract(this.gameObject);
        }

    }

    void FixedUpdate()
    {
        if (!Physics2D.Raycast(this.transform.position, Vector2.down, this.m_RaycastFloorDistance, m_FloorLayer))
        {
            this.m_Move.y = -5f;
        }
        else
        {
            this.m_Move.y = 0f;
        }


        this.m_rb.AddForce(m_Move * m_SpeedMultiplier * Time.deltaTime);
        //this.m_rb.velocity = this.m_Move * m_SpeedMultiplier * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("PlatformerInteractable"))
        {
            if (hit.gameObject.TryGetComponent<InteractableCard>(out this.m_InteractableCard))
            {
                this.m_InteractableCard.HighlightCard(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (this.m_InteractableCard != null)
        {
            this.m_InteractableCard.HighlightCard(false);
            this.m_InteractableCard = null;
        }
    }
}
