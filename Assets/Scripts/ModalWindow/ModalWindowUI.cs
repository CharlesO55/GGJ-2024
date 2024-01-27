using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ModalWindowUI : MonoBehaviour
{
    public static ModalWindowUI Instance { get; private set; }
    
    private TextMeshProUGUI textmeshPro;
    private Button yesBtn;
    private Button noBtn;
    private void Awake()
    {
        Instance = this;
        
        textmeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        yesBtn = transform.Find("yesBtn").GetComponent<Button>();
        noBtn = transform.Find("noBtn").GetComponent<Button>();
        
        Hide();
    }

    public void Show(string message, Action yesAction, Action noAction)
    {
        gameObject.SetActive(true);
        
        textmeshPro.text = message;
        yesBtn.onClick.AddListener(() =>
        {
            Hide();
            yesAction();
        });
        noBtn.onClick.AddListener(() =>
        {
            Hide();
            noAction();
        });
    }

    private void Hide()
    {
        yesBtn.onClick.RemoveAllListeners();
        noBtn.onClick.RemoveAllListeners();
        
        gameObject.SetActive(false);
    }
}
