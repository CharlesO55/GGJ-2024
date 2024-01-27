using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ResultsScreenManager : MonoBehaviour
{
    public static ResultsScreenManager Instance;

    private VisualElement m_root;

    private Label m_title;
    private Label m_body;
    private Image m_image;


    private Button m_continueBtn;
    private Button m_restartGameBtn;
    private Button m_restartStageBtn;

    private int m_nextSceneIndex;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        this.m_root = GetComponent<UIDocument>().rootVisualElement;

        this.m_title = this.m_root.Q<Label>("Title");
        this.m_body = this.m_root.Q<Label>("Body");
        this.m_image = this.m_root.Q<Image>("ResultImage");

        this.m_restartStageBtn = this.m_root.Q<Button>("RestartStage");
        this.m_restartStageBtn.RegisterCallback<ClickEvent>(evt =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        this.m_restartGameBtn = this.m_root.Q<Button>("RestartGame");
        this.m_restartGameBtn.RegisterCallback<ClickEvent>(evt =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        });

        this.m_continueBtn = this.m_root.Q<Button>("ContinueBtn");
        this.m_continueBtn.RegisterCallback<ClickEvent>(evt =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(this.m_nextSceneIndex);
        });



    }

    void OnDestroy()
    {
        this.m_root.Q<Button>("RestartStage").UnregisterCallback<ClickEvent>(evt =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        this.m_root.Q<Button>("RestartGame").UnregisterCallback<ClickEvent>(evt =>
        {
            SceneManager.LoadScene(0);
        });
        this.m_continueBtn.UnregisterCallback<ClickEvent>(evt =>
        {
            SceneManager.LoadScene(this.m_nextSceneIndex);
        });
    }

    public void ShowFailResult(string title, string body, Texture texImage)
    {
        Time.timeScale = 0.1f;

        this.m_root.Q<VisualElement>("Screen").style.display = DisplayStyle.Flex;

        this.m_continueBtn.style.display = DisplayStyle.None;
        this.m_restartStageBtn.style.display = DisplayStyle.Flex;
        this.m_restartGameBtn.style.display = DisplayStyle.Flex;

        this.m_title.text = title;
        this.m_body.text = body;

        this.m_image.image = texImage;
    }


    public void ShowPassResult(string title, string body, Texture texImage, int nNextSceneIndex)
    {
        Time.timeScale = 0.1f;

        this.m_nextSceneIndex = nNextSceneIndex;

        this.m_root.Q<VisualElement>("Screen").style.display = DisplayStyle.Flex;

        this.m_continueBtn.style.display = DisplayStyle.Flex;
        this.m_restartStageBtn.style.display = DisplayStyle.None;
        this.m_restartGameBtn.style.display = DisplayStyle.None;

        this.m_title.text = title;
        this.m_body.text = body;

        this.m_image.image = texImage;
    }
}
