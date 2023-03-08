using UnityEngine;


public class DraggableUI : MonoBehaviour
{
    [SerializeField] private GameObject _joystickObj;
    private Joystick _joystick;
    private void Start()
    {
        _joystickObj.gameObject.GetComponent<Joystick>();
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
        //if (_touch.phase == TouchPhase.Began)
        //{
        //    _joystick.PositionTransfer(_touch);
        //    _joystick.ChackClick(true);
        //    _joystickObj.transform.position = _touch.position;
        //}
        //else
        //if (_touch.phase == TouchPhase.Moved)
        //{
        //    _joystick.PositionTransfer(_touch);
        //}
        //else
        //if (_touch.phase == TouchPhase.Ended)
        //{
        //    _joystick.ChackClick(false);
        //}
    }
}