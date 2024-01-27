using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject m_target;
    private Rigidbody2D m_targetRb;

    [SerializeField] private float m_camOffset;

    private Camera m_Camera;


    void Start()
    {
        this.TryGetComponent(out m_Camera);

        m_target.TryGetComponent<Rigidbody2D>(out m_targetRb);

    }


    void LateUpdate()
    {
        this.transform.position = m_target.transform.position - Vector3.back * -5;

        this.m_Camera.orthographicSize = 
            Mathf.Lerp(this.m_Camera.orthographicSize, 
                5 + m_targetRb.velocity.normalized.magnitude * -m_camOffset + (m_targetRb.transform.position.y * 0.5f), 
                Time.deltaTime);

        //this.m_Camera.orthographicSize = 5 + m_targetRb.velocity.magnitude * -m_camOffset;
    }
}
