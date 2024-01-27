using Cinemachine;
using UnityEngine;

namespace BukoClimbers
{
    public class CameraRegister : MonoBehaviour
    {
        private void OnEnable()
        {
            CameraSwitcher.Register(GetComponent<CinemachineVirtualCamera>());
        }

        private void OnDisable()
        {
            CameraSwitcher.Unregister(GetComponent<CinemachineVirtualCamera>());
        }
    }
}