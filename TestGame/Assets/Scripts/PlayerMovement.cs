using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private Vector2 _joystickPosition = Vector2.zero;
    void Start()
    {
        
    }

    void Update()
    {
        _joystickPosition = _joystick.GetJoystickPosition();
        
    }
}
