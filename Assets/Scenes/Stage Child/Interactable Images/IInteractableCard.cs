using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableCard: MonoBehaviour
{
    [SerializeField] private float m_flipTime = 0.5f;
    private bool m_isHighlighted = false;

    public virtual void OnCardInteract(GameObject sender)
    {
        Debug.Log("Interacted with card: " + this.name);
    }

    public void HighlightCard(bool ToF)
    {
        if (this.TryGetComponent(out SpriteRenderer renderer))
        {

            if (ToF)
            {
                renderer.color = new Color(100, 100, 0.5f, 1f);

                this.m_isHighlighted = true;
                this.StartCoroutine(RotateCard(renderer));
            }
            else
            {
                renderer.color = Color.white;
                
                this.m_isHighlighted = false;
                renderer.flipX = false;

                this.StopCoroutine(RotateCard(renderer));
            }

        }
    }

    IEnumerator RotateCard(SpriteRenderer renderer)
    {
        while (this.m_isHighlighted)
        {
            Transform targetTransform = this.transform.gameObject.transform;

            renderer.flipX = !renderer.flipX;
            

            
            yield return new WaitForSeconds(this.m_flipTime);
        }
    }
}