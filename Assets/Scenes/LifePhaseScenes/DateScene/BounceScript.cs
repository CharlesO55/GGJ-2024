using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_rb;
    [SerializeField] private float m_force = 5;

    void Start()
    {
        Vector2 randDir = new Vector2(Random.Range(-1, 0), Random.Range(-0.5f, -1));

        m_rb.AddForce(randDir * m_force, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //.
        //Vector3 direction = collision.contacts[0]..position - transform.position;

        /*direction = direction.normalized;
        Debug.Log("Dir: " + direction);
*/


        //direction.z = transform.position.z;
        //m_rb.velocity = direction * 5;

        m_rb.AddForce(collision.contacts[0].normal * m_force, ForceMode2D.Impulse);
    }


    void Update()
    {
        if (Vector3.Distance(this.transform.position, Vector3.zero) > 50)
        {
            Debug.LogWarning("out of bounds");
            Vector3 pos = this.transform.position;
            pos.y = 0;
            pos.x = 0;

            transform.position = pos;
        }
    }
}
