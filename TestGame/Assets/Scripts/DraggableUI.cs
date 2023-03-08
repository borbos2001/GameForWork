using UnityEngine;


public class DraggableUI : MonoBehaviour
{
    [SerializeField] private GameObject _joystickObj;
    private Joystick _joystick;
    private void Start()
    {
        _joystick = _joystickObj.gameObject.GetComponent<Joystick>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            JoystickPosition(_touch);
        }
    }
    private void JoystickPosition(Touch _touchInfo)
    {
        if (_touchInfo.phase == TouchPhase.Began)
        {
            _joystick.PositionTransfer(_touchInfo);
            _joystick.ChackClick(true);
            _joystickObj.transform.position = _touchInfo.position;
        }
        else
        if (_touchInfo.phase == TouchPhase.Moved)
        {
            _joystick.PositionTransfer(_touchInfo);
        }
        else
        if (_touchInfo.phase == TouchPhase.Ended)
        {
            _joystick.ChackClick(false);
        }
    }
}