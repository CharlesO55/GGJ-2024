using System;
using System.Threading;
using BukoClimbers;
using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    [SerializeField] private GameObject truckKun;
    [SerializeField] private Sprite deathSprite;
    [SerializeField] private GameObject blocker;
    private float timer = 2f;

    private bool isTriggered = false;
    private Collider2D player;
    private bool playOnce = true;

    private void Update()
    {
        if (!isTriggered) return;
        if(playOnce)
        {
            playOnce = false;
            AudioManager.Instance.PlaySfx("Truck_Kun");
        }
        if (timer < 0)
        {
            player.transform.GetComponent<ChildDeathHandler>().HandleDeath(deathSprite);
            truckKun.SetActive(true);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            blocker.SetActive(true);
            player = other;
            isTriggered = true;
            
        }
    }
}
