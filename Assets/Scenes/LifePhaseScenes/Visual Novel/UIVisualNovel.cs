using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIVisualNovel : MonoBehaviour
{
    private VisualElement m_root;

    private VisualElement m_ButtonsContainer;
    private VisualElement m_DialogueBox;

    public List<Button> m_Buttons { private set; get; } = new List<Button>();
    public Label m_speakerLabel { private set; get; }
    public Label m_textLabel { private set; get; }

    void Start()
    {
        m_root = GetComponent<UIDocument>().rootVisualElement;

        this.m_ButtonsContainer = m_root.Q<VisualElement>("ButtonsButtons");
        this.m_ButtonsContainer = m_root.Q<VisualElement>("DialoguePanel");


        this.m_speakerLabel = m_root.Q<Label>("Speaker");
        this.m_textLabel = m_root.Q<Label>("DialogueText");

        for (int i = 1; i <= 4; i++)
        {
            this.m_Buttons.Add(
                this.m_root.Q<Button>("Choice"+i.ToString()));

        }

        foreach (Button btn in this.m_Buttons)
        {
            btn.RegisterCallback<ClickEvent>(DeclareButtonPress);
        }

        this.ToggleAll(false);
    }

    void OnDestroy()
    {
        foreach (Button btn in this.m_Buttons)
        {
            btn.UnregisterCallback<ClickEvent>(DeclareButtonPress);
        }
    }

    void DeclareButtonPress(ClickEvent evt)
    {
        Debug.Log("BUTTON: " + evt.currentTarget);
    }

    void ToggleAll(bool ToF)
    {
        DisplayStyle dstyle = ToF ? DisplayStyle.Flex : DisplayStyle.None;
        
        this.m_root.style.display = dstyle;
    }

    void ToggleButtons(bool ToF)
    {
        DisplayStyle dstyle = ToF ? DisplayStyle.Flex : DisplayStyle.None;

        this.m_ButtonsContainer.style.display = dstyle;
    }

    void ToggleDialogueBox(bool ToF)
    {

        DisplayStyle dstyle = ToF ? DisplayStyle.Flex : DisplayStyle.None;

        this.m_DialogueBox.style.display = dstyle;
    }
}
