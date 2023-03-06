using UnityEngine;


public class DraggableUI : MonoBehaviour
{
    [SerializeField] private Transform _joystickTransform;
    private Joystick _joystick;
    private void Start()
    {
        _joystick = _joystickTransform.GetComponent<Joystick>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            JoystickPositionControl(_touch);
        }
    }
    private void JoystickPositionControl(Touch _touch)
    {
        if (_touch.phase == TouchPhase.Began)
        {
            _joystickTransform.position = _touch.position;
        }
    }
}