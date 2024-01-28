using UnityEngine;
using UnityEngine.UIElements;

public class CrossyRoadsUI : MonoBehaviour
{
    public static CrossyRoadsUI Instance;


    private Label m_scoreCounter;
    private float m_Coins;

    

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
        this.m_scoreCounter = GetComponent<UIDocument>().rootVisualElement.Q<Label>("Coins");
    }
    public void IncrementCoin()
    {
        this.m_Coins++;

        m_scoreCounter.text = this.m_Coins.ToString() + "\u00a2";
    }
}
