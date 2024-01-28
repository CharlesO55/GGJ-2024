using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{

    [SerializeField] private List<Sprite> m_sprites = new();
    private int m_currSpriteIndex;

    public static SpriteSpawner Instance;

    public bool m_StartShowingSprites = false;

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
    public Sprite GetNewSprite()
    {
        m_currSpriteIndex++;

        if (m_currSpriteIndex >= m_sprites.Count)
        {
            m_currSpriteIndex = 0;
        }


        Time.timeScale = 1;
        return this.m_sprites[m_currSpriteIndex];
    }

}
