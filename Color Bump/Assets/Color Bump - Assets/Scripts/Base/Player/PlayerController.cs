using System;
using UnityEngine;

public enum ColorType { White,Black,Yellow,Red,Orange}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private ColorType colorType;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;
    [SerializeField] private CameraSettings cameraSettings;

    [SerializeField] private float sensitivity;
    [SerializeField] private float clampDelta;
    [SerializeField] private float bounds;

    private Vector3 lastTouchPosition;

    private delegate float offset();
    private offset OnPlayerOffset;

    private float zPos = 0.65f;
    private void Start()
    {
        OnPlayerOffset = OnZOffsetChange;
    }
    void FixedUpdate()
    {
        SetRbMovement();
        SetTransformMove();
    }
    private float OnZOffsetChange()
    {
        // zPos += Time.deltaTime;
        // zPos = zPos >= .5f ? 0f : zPos;

        return zPos;
    }
    void SetTransformMove()
    {
        float xPosBound = Mathf.Clamp(transform.position.x, -bounds, bounds);
        float zPosBound = Mathf.Clamp(transform.position.z, cam.transform.position.z + zPos, transform.position.z);

        Debug.Log("ZPos" + zPos);

        transform.position = new Vector3(xPosBound,transform.position.y,zPosBound);
        // transform.position += cameraSettings.CameraVelocity;
    }
    void SetRbMovement()
    {
        var isTouching = Input.GetMouseButtonDown(0);
        var touching = Input.GetMouseButton(0);
        if (isTouching)
        {
            lastTouchPosition = Input.mousePosition;
        }
        if (touching)
        {
            Vector3 touchingPos = Input.mousePosition;
            Vector3 vector = touchingPos - lastTouchPosition;

            lastTouchPosition = Input.mousePosition;
            vector = new Vector3(vector.x, 0, vector.y);

            Vector3 calculateMove = new Vector3(vector.x,0,vector.z);
            

            Vector3 moveForce = Vector3.ClampMagnitude(calculateMove, clampDelta);
            Debug.Log("CalculateMove" + calculateMove.magnitude);
            rb.AddForce(moveForce * sensitivity,ForceMode.VelocityChange);
        }
    }
}
