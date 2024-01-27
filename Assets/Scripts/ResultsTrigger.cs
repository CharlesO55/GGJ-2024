using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ResultsTrigger : MonoBehaviour
{
    [SerializeField] private Texture m_image;
    [SerializeField] private string m_title;
    [SerializeField] private string m_description;

    [Description("True for fail result screens.")]
    [SerializeField] bool m_IsFailTrigger = true;

    [Header("Next scene if Pass/Success")]
    [SerializeField] private int m_nextSceneIndex;

    public void ActivateResultsTrigger()
    {
        if (m_IsFailTrigger)
        {
            ResultsScreenManager.Instance.ShowFailResult(m_title, m_description, m_image);
        }
        else
        {
            ResultsScreenManager.Instance.ShowPassResult(m_title, m_description, m_image, m_nextSceneIndex);
        }
    }
}
