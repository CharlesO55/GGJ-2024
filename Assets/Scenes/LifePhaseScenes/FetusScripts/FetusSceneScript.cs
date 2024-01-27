using System;
using UnityEngine;

public class FetusSceneScript : MonoBehaviour
{
    public static event EventHandler OnSpacePressed;
    public static event EventHandler OnPhaseEnd;
    private int progression = 0;

    [SerializeField] private SpriteRenderer fetusBackgroundImage;
    [SerializeField] private Sprite[] fetusStageSprites;
    private bool _isFetusSpriteNotNull;


    private void Start()
    {
        _isFetusSpriteNotNull = fetusStageSprites.Length == 3;
        FetusSpaceScript.OnInputSuccess += FetusBarScript_OnInputSuccess;
        FetusSpaceScript.OnInputFailed += FetusBarScript_OnInputFailed;
    }

    private void FetusBarScript_OnInputFailed(object sender, EventArgs e)
    {
        progression -= 2;
        progression = Mathf.Clamp(progression ,0, 3);
        ScreenShake.Instance.ShakeScreen(0.2f);
        UpdateFetusStageSprite();
    }

    private void FetusBarScript_OnInputSuccess(object sender, EventArgs e)
    {
        progression++;
        progression = Mathf.Clamp(progression ,0, 3);
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
        return progression >= 2;
    }
}
