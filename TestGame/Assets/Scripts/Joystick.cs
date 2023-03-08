using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick : MonoBehaviour
{
    private RectTransform _joystickBackground;
    private RectTransform _joystickHandle;
    private Vector2 _joystickPosition = Vector2.zero;
    private float _joystickRadius;
    private bool _pressed;
    private Touch _touch;
    private void Start()
    {
        _joystickBackground = GetComponent<RectTransform>();
        _joystickHandle = transform.GetChild(0).GetComponent<RectTransform>();
        _joystickRadius = _joystickBackground.sizeDelta.x / 2;
    }
    private void FixedUpdate()
    {
        if(_pressed == true)
        {
            OnDrag(_touch);
        }
    }
    public void ChackClick(bool pressed)
    {
        _pressed = pressed;
    }
    public void PositionTransfer(Touch touch)
    {
        _touch = touch;
    }
    public void OnDrag(Touch touch)
    {
        Vector2 delta = touch.position - (Vector2)_joystickBackground.position;
        delta = Vector2.ClampMagnitude(delta, _joystickRadius);
        _joystickHandle.anchoredPosition = delta;
        _joystickPosition = delta / _joystickRadius;
    }
    public Vector2 GetJoystickPosition()
    {
        return _joystickPosition;
    }
     
}