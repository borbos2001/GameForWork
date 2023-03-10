
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
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
        if (_pressed == true)
        {
            OnDrag(_touch);
            _playerMovement.Move(_joystickPosition);
        }
    }
    public void ChackClick(bool pressed)
    {
        _pressed = pressed;
        _playerMovement.AnimationControll(_pressed);
        if (_pressed==false)
        {
            OnTouchUp();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
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
    public void OnTouchUp()
    {
        _joystickHandle.anchoredPosition = Vector2.zero;
        _joystickPosition = Vector2.zero;
    }
}