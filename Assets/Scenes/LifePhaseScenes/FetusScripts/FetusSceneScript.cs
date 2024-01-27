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
    private int maxProgression = 5;

    [SerializeField] private TextMeshProUGUI progressionUI;
    [SerializeField] private Image fetusBackgroundImage;

    private void Start()
    {
        FetusSpaceScript.OnInputSuccess += FetusBarScript_OnInputSuccess;
        FetusSpaceScript.OnInputFailed += FetusBarScript_OnInputFailed;
    }

    private void FetusBarScript_OnInputFailed(object sender, EventArgs e)
    {
        progression -= 2;
        progression = Mathf.Clamp(progression ,0, 3);
        progressionUI.text = progression.ToString();
        // todo - fetusBackgroundImage.sprite = fetusSprite[progression];
    }

    private void FetusBarScript_OnInputSuccess(object sender, EventArgs e)
    {
        progression++;
        progression = Mathf.Clamp(progression ,0, 3);
        progressionUI.text = progression.ToString();
        // todo - fetusBackgroundImage.sprite = fetusSprite[progression];
        if (CheckProgression())
        {
            OnPhaseEnd?.Invoke(this, EventArgs.Empty);
            //todo - sceneloader next scene
        }
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
