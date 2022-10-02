using UnityEngine;

[CreateAssetMenu(fileName ="CameraSettings",menuName ="Camera/CameraSettings")]
public class CameraSettings : ScriptableObject
{
    [SerializeField] private float cameraSpeed;
    public float CameraSpeed { get { return cameraSpeed; }  }

    [SerializeField] private Vector3 cameraVelocity;
    public Vector3 CameraVelocity { get { return cameraVelocity; } set { cameraVelocity = value; } }
}
