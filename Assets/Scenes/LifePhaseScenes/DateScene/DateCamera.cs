using System;
using Cinemachine;
using UnityEngine;

public class DateCamera : MonoBehaviour
{
    [SerializeField] float m_maxZoom = 1;
    [SerializeField] float m_minZoom = 5;
    [SerializeField] private float m_zoomSpeed = 2;

    private CinemachineVirtualCamera m_cam;

    [SerializeField] private MouseFollower m_cusor;

    private bool m_isZoomIn = true;

    [SerializeField] float m_zoomOutSpeed = 25;
    void Start()
    {
        
        this.m_cam = GetComponent<CinemachineVirtualCamera>();

        m_cusor.OnScreenMoved += ZoomOut;
    }

    void LateUpdate()
    {
        Zoom(this.m_isZoomIn);

        this.m_isZoomIn = true;
    }


    void ZoomOut(object sender, EventArgs e)
    {
        this.m_isZoomIn = false;
    }


    void Zoom(bool bZoomIn)
    {
        float zooming;


        if (bZoomIn)
            zooming = -1;
        else
        {
            zooming = m_zoomOutSpeed;
        }

        float currZoom = this.m_cam.m_Lens.OrthographicSize;

        currZoom = Mathf.Lerp(
            currZoom, 
            currZoom + m_zoomSpeed * Time.deltaTime * zooming, 0.5f);

        currZoom = Mathf.Clamp(currZoom, m_maxZoom, m_minZoom);

        this.m_cam.m_Lens.OrthographicSize = currZoom;
    }
}
