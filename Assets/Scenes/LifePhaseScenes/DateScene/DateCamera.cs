using Cinemachine;
using UnityEngine;

public class DateCamera : MonoBehaviour
{
    [SerializeField] float m_maxZoom = 1;
    [SerializeField] float m_minZoom = 5;
    [SerializeField] private float m_zoomSpeed = 2;

    private CinemachineVirtualCamera m_cam;

    void Start()
    {
        this.m_cam = GetComponent<CinemachineVirtualCamera>();
    }

    void LateUpdate()
    {
        ZoomIn();


    }

    void ZoomIn()
    {
        float currZoom = this.m_cam.m_Lens.OrthographicSize;

        currZoom = Mathf.Lerp(
            currZoom, 
            currZoom + m_zoomSpeed * Time.deltaTime * -1, 0.5f);

        currZoom = Mathf.Clamp(currZoom, m_maxZoom, m_minZoom);

        this.m_cam.m_Lens.OrthographicSize = currZoom;
    }
}
