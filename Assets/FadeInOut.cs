using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    SpriteRenderer m_spriteRenderer;

    [SerializeField] private float m_fadeSpeed = 1;

    private float m_currFadeSpeed;
    [SerializeField] private float m_currFade = 1;


    

    void Start()
    {
        this.m_spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        if (!SpriteSpawner.Instance.m_StartShowingSprites)
            return;

        
        if (m_currFade <= 0)
        {
            this.m_currFadeSpeed = m_fadeSpeed;
            this.m_spriteRenderer.sprite = SpriteSpawner.Instance.GetNewSprite();

        }
        else if (m_currFade >= 1)
        {
            this.m_currFadeSpeed = -m_fadeSpeed;

        }


        this.m_currFade += m_currFadeSpeed * Time.deltaTime;
        this.m_spriteRenderer.color = new Color(100, 100, 100, this.m_currFade);
    }
}
