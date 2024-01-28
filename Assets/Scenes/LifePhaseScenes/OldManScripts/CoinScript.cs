using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Rigidbody2D m_rb;
    void Awake()
    {
        m_rb = this.AddComponent<Rigidbody2D>();
        m_rb.gravityScale = 0;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            CrossyRoadsUI.Instance?.IncrementCoin();

            this.m_rb.AddForce(Vector2.up * 500, ForceMode2D.Impulse);
            StartCoroutine("DestroyLater");
        }
        
    }

    IEnumerator DestroyLater()
    {
        yield return new WaitForSeconds(0.3f);
        this.m_rb.AddForce(Vector2.down * 1000, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.3f);

        Destroy(this.gameObject);
    }
}
