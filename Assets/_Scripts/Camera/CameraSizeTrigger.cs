using Cinemachine;
using UnityEngine;

namespace BukoClimbers
{
    public class CameraSizeTrigger : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cam;
        [SerializeField] private CinemachineVirtualCamera playerCam;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log("Entered");
            if (other.CompareTag("Player"))
                if(CameraSwitcher.ActiveCamera != cam) CameraSwitcher.SwitchCamera(cam);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            //Debug.Log("Exited");
            if (other.CompareTag("Player"))
                if(CameraSwitcher.ActiveCamera != playerCam) CameraSwitcher.SwitchCamera(playerCam);
        }
    }
}
