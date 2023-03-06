using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerEnterHandler
{
    private RectTransform _joystickBackground;
    private RectTransform _joystickHandle;
    private Vector2 _joystickPosition = Vector2.zero;
    private float _joystickRadius;
    private void Start()
    {
        _joystickBackground = GetComponent<RectTransform>();
        _joystickHandle = transform.GetChild(0).GetComponent<RectTransform>();
        _joystickRadius = _joystickBackground.sizeDelta.x / 2;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - (Vector2)_joystickBackground.position;
        delta = Vector2.ClampMagnitude(delta, _joystickRadius);
        _joystickHandle.anchoredPosition = delta;
        _joystickPosition = delta / _joystickRadius;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickHandle.anchoredPosition = Vector2.zero;
        _joystickPosition = Vector2.zero;
    }
    public Vector2 GetJoystickPosition()
    {
        return _joystickPosition;
    }
}