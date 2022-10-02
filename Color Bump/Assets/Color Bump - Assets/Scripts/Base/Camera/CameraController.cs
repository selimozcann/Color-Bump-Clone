using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    void LateUpdate()
    {
        transform.position += Vector3.forward * cameraSettings.CameraSpeed * Time.deltaTime;  
    }
}
