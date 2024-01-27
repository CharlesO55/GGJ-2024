using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.TryGetComponent<ResultsTrigger>(out var res))
            {
                res.ActivateResultsTrigger();
            }
        }
    }
}
