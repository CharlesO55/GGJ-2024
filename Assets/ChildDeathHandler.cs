using UnityEngine;

public class ChildDeathHandler : MonoBehaviour
{
    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void ChangeSprite(Sprite deathSprite)
    {
        sr.sprite = deathSprite;
    }

    public void HandleDeath(Sprite deathSprite)
    {
        ChangeSprite(deathSprite);
    }
}
