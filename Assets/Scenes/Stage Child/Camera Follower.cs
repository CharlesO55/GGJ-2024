using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject m_target;
    [SerializeField] private float m_camOffset;

    void LateUpdate()
    {
        this.transform.position = m_target.transform.position - Vector3.back * m_camOffset;
    }
}
