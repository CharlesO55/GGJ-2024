using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public GameObject m_targetObject = null;

    [SerializeField] float m_speed = 1f;

    [SerializeField] private float m_edgeSize = 20f;


    [SerializeField] private Vector2 m_transformLimit = new Vector2(7.75f, 1.2f);


    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit != null && hit.collider != null)
        {
            Debug.Log("Hit" + hit.collider.name);
        }
    }
    void LateUpdate()
    {
        ScrollMovement();
    }

    void ScrollMovement()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 moveBy = this.transform.position;


        //Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        //Debug.Log( Camera.main.ViewportToWorldPoint(new Vector3(-1, -1, Camera.main.nearClipPlane)));

        if (mousePos.x < m_edgeSize && moveBy.x > -m_transformLimit.x)
        {
            moveBy.x -= Time.deltaTime * m_speed;
        }
        else if (mousePos.x > Screen.width - m_edgeSize && moveBy.x < m_transformLimit.x)
        {
            moveBy.x += Time.deltaTime * m_speed;
        }

        if (mousePos.y < m_edgeSize && moveBy.y > -m_transformLimit.y)
        {
            moveBy.y -= Time.deltaTime * m_speed;
        }
        else if (mousePos.y > Screen.height - m_edgeSize && moveBy.y < m_transformLimit.y)
        {
            moveBy.y += Time.deltaTime * m_speed;
        }

        this.transform.position = moveBy;
    }
}
