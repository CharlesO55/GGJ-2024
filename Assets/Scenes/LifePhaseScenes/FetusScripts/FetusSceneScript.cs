using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class FetusSceneScript : MonoBehaviour
{
    public static event EventHandler OnSpacePressed;
    public static event EventHandler OnPhaseEnd;
    private int progression = 0;

    [SerializeField] private TextMeshProUGUI progressionUI;
    [SerializeField] private Image fetusBackgroundImage;
    [SerializeField] private Sprite[] fetusStageSprites;
    private bool _isFetusSpriteNotNull;

    private void Start()
    {
        _isFetusSpriteNotNull = fetusStageSprites.Length == 4;
        FetusSpaceScript.OnInputSuccess += FetusBarScript_OnInputSuccess;
        FetusSpaceScript.OnInputFailed += FetusBarScript_OnInputFailed;
    }

    private void FetusBarScript_OnInputFailed(object sender, EventArgs e)
    {
        progression -= 2;
        progression = Mathf.Clamp(progression ,0, 3);
        progressionUI.text = progression.ToString();
        ScreenShake.Instance.ShakeScreen(0.04f);
        UpdateFetusStageSprite();
    }

    private void FetusBarScript_OnInputSuccess(object sender, EventArgs e)
    {
        progression++;
        progression = Mathf.Clamp(progression ,0, 3);
        progressionUI.text = progression.ToString();
        UpdateFetusStageSprite();
        if (CheckProgression())
        {
            OnPhaseEnd?.Invoke(this, EventArgs.Empty);
            //todo - sceneloader next scene
        }
    }

    void UpdateFetusStageSprite()
    {
        if(_isFetusSpriteNotNull)
            fetusBackgroundImage.sprite = fetusStageSprites[progression];
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
        }
        
    }

    private bool CheckProgression()
    {
        return progression >= 3;
    }
}
