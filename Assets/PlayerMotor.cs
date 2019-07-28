using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camrotation = Vector3.zero;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        PerformCameraRotation();
    }


    /*
     * Vertical camera movement
     */
    private void PerformCameraRotation()
    {
        if (cam != null)
        {
            cam.transform.Rotate(camrotation);
        }
    }

    internal void VerticalCameraRotate(Vector3 rotationVector)
    {
        camrotation = rotationVector;
    }


    /*
     * Horizontal camera movement.
     */

    private void PerformRotation()
    {
        if (rotation != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        }
    }

    internal void HorizontalCameraRotate(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }


    /*
     * Movement
     */
    internal void Move(Vector3 movementVector)
    {
        velocity = movementVector;
    }
    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + (velocity * Time.deltaTime));
        }
    }


}
