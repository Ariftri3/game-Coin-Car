using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider frontLeftCollider;
    public WheelCollider frontRightCollider;
    public WheelCollider backLeftCollider;
    public WheelCollider backRightCollider;

    [Header("Wheel Meshes")]
    public Transform frontLeftMesh;
    public Transform frontRightMesh;
    public Transform backLeftMesh;
    public Transform backRightMesh;

    [Header("Car Settings")]
    public float motorForce = 1500f;
    public float brakeForce = 3000f;
    public float maxSteerAngle = 30f;

    private float horizontalInput;
    private float verticalInput;
    private bool isBraking;

    void Update()
    {
        horizontalInput = 0;
        verticalInput = 0;
        isBraking = false;

        // Keyboard
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                horizontalInput = -1;

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                horizontalInput = 1;

            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                verticalInput = 1;

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                verticalInput = -1;

            if (Keyboard.current.spaceKey.isPressed)
                isBraking = true;
        }

        // Mobile
        if (Mathf.Abs(MobileInput.Horizontal) > 0.1f)
            horizontalInput = MobileInput.Horizontal;

        if (MobileInput.Vertical != 0)
            verticalInput = MobileInput.Vertical;

        if (MobileInput.Brake)
            isBraking = true;
    }

    void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheelPoses();
    }

    void HandleMotor()
    {
        backLeftCollider.motorTorque = verticalInput * motorForce;
        backRightCollider.motorTorque = verticalInput * motorForce;

        float currentBrake = isBraking ? brakeForce : 0f;

        frontLeftCollider.brakeTorque = currentBrake;
        frontRightCollider.brakeTorque = currentBrake;
        backLeftCollider.brakeTorque = currentBrake;
        backRightCollider.brakeTorque = currentBrake;
    }

    void HandleSteering()
    {
        float steer = horizontalInput * maxSteerAngle;

        frontLeftCollider.steerAngle = steer;
        frontRightCollider.steerAngle = steer;
    }

    void UpdateWheelPoses()
    {
        UpdateWheel(frontLeftCollider, frontLeftMesh);
        UpdateWheel(frontRightCollider, frontRightMesh);
        UpdateWheel(backLeftCollider, backLeftMesh);
        UpdateWheel(backRightCollider, backRightMesh);
    }

    void UpdateWheel(WheelCollider col, Transform wheel)
    {
        Vector3 pos;
        Quaternion rot;

        col.GetWorldPose(out pos, out rot);

        wheel.position = pos;
        wheel.rotation = rot;
    }
}