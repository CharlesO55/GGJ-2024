using BukoClimbers;
using Cinemachine;
using UnityEngine;

public class ManualSwitchCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerCam;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")) CameraSwitcher.SwitchCamera(playerCam);
    }
}
