using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerScript : MonoBehaviour
{

    // Makes it visible in unity inspector.
    private readonly float playerSpeed = 7;
    private readonly float lookSpeed = 10;

    private PlayerMotor motor;

    void Start()
    {
        Debug.Log("Player init.");
        motor = GetComponent<PlayerMotor>();

    }

    // Update is called once per frame
    void Update()
    {
        MovementCalculations();
        RotationCalcuations();
        CameraRotationCalculations();


    }

    private void CameraRotationCalculations()
    {
        float yRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 rot = new Vector3(-yRotation, 0f, 0f) * lookSpeed;

        motor.VerticalCameraRotate(rot);
    }

    private void RotationCalcuations()
    {
        float xRotation = Input.GetAxisRaw("Mouse X");
        Vector3 rot = new Vector3(0f, xRotation, 0f) * lookSpeed;

        motor.HorizontalCameraRotate(rot);
    }

    private void MovementCalculations()
    {
        float horMov = Input.GetAxisRaw("Horizontal");
        float verMov = Input.GetAxisRaw("Vertical");

        Vector3 appliedHorMovement = transform.right * horMov; // Red axis, left/right.
        Vector3 appliedVerMovement = transform.forward * verMov; // Blue axis, forward/back.

        // AAA! .normalized is something I have accounted for so often, very easy here:
        Vector3 appliedTotalMovement = (appliedHorMovement + appliedVerMovement).normalized * playerSpeed;

        Debug.Log("H: " + horMov + " V: " + verMov + " MOVEMENT VECTOR: " + appliedTotalMovement.x + ", " + appliedTotalMovement.y + ", " + appliedTotalMovement.z);

        motor.Move(appliedTotalMovement);
    }
}
