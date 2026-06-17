using UnityEngine;
// 1. Wajib menambahkan namespace Input System baru
using UnityEngine.InputSystem; 

public class CarController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider frontLeftCollider;
    public WheelCollider frontRightCollider;
    public WheelCollider backLeftCollider;
    public WheelCollider backRightCollider;

    [Header("Wheel Meshes (Visual)")]
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
        // 2. Mengambil input menggunakan Input System baru (Keyboard/Gamepad otomatis terdeteksi)
        
        // Membaca input WASD atau Arrow Keys untuk berbelok (A/D atau Left/Right)
        if (Keyboard.current != null)
        {
            // Input Horizontal (A/D atau Kiri/Kanan)
            horizontalInput = 0f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) horizontalInput = 1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) horizontalInput = -1f;

            // Input Vertical (W/S atau Atas/Bawah)
            verticalInput = 0f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) verticalInput = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) verticalInput = -1f;

            // Input Rem (Spasi)
            isBraking = Keyboard.current.spaceKey.isPressed;
        }
    }

    void FixedUpdate()
    {
        // Tetap sama karena urusan fisika tidak berubah
        HandleMotor();
        HandleSteering();
        UpdateWheelPoses();
    }

    private void HandleMotor()
    {
        backLeftCollider.motorTorque = verticalInput * motorForce;
        backRightCollider.motorTorque = verticalInput * motorForce;

        float currentBrake = isBraking ? brakeForce : 0f;
        ApplyBraking(currentBrake);
    }

    private void ApplyBraking(float force)
    {
        frontLeftCollider.brakeTorque = force;
        frontRightCollider.brakeTorque = force;
        backLeftCollider.brakeTorque = force;
        backRightCollider.brakeTorque = force;
    }

    private void HandleSteering()
    {
        float currentSteerAngle = horizontalInput * maxSteerAngle;
        frontLeftCollider.steerAngle = currentSteerAngle;
        frontRightCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheelPoses()
    {
        UpdateSingleWheel(frontLeftCollider, frontLeftMesh);
        UpdateSingleWheel(frontRightCollider, frontRightMesh);
        UpdateSingleWheel(backLeftCollider, backLeftMesh);
        UpdateSingleWheel(backRightCollider, backRightMesh);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}