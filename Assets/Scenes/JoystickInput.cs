using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    public FixedJoystick joystick;

    void Update()
    {
        MobileInput.Horizontal = joystick.Horizontal;
    }
}