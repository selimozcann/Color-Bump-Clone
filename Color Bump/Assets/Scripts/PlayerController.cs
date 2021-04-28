using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastMousePos;
    public float sensitivity = 0.16f ,clampDelta = 42f;

    public float bounds = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-bounds,bounds),transform.position.y,transform.position.z);
        transform.position += FindObjectOfType<CameraFollow>().camVel;
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
            Debug.Log("Down");
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 vector = lastMousePos - Input.mousePosition;
            lastMousePos = Input.mousePosition;
            vector = new Vector3(vector.x, 0, vector.y);

            Vector3 moveForce = Vector3.ClampMagnitude(vector,clampDelta);
            rb.AddForce(Vector3.forward * 2 + (-moveForce * sensitivity - rb.velocity ),ForceMode.VelocityChange);
        }   
    }
}
