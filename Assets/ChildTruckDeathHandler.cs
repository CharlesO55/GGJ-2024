using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ChildTruckDeathHandler : MonoBehaviour
{
    [SerializeField] private Sprite deathSprite;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void ChangeSprite()
    {
        sr.sprite = deathSprite;
    }

    public void HandleDeath(Transform roadTransform)
    {
        Destroy(rb);
        ChangeSprite();
    }
}
