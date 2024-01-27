using System;
using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    [SerializeField] private GameObject truckKun;
    private float timer = 3f;
    private bool isTriggered = false;
    private void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            other.gameObject.SetActive(false);
            truckKun.SetActive(true);
        }
    }
}
