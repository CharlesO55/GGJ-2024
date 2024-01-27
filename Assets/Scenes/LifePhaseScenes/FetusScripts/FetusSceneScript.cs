using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetusSceneScript : MonoBehaviour
{
    [SerializeField] private float timer = 20f;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else{ 
            Debug.Log("ChangeScene");
        }
    }
}