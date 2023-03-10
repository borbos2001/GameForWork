
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    private Animator _animator;

    private Rigidbody _rb;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 joystickPosition)
    {
        float _horizontal = -joystickPosition.x;
        float _vertical = -joystickPosition.y;
        Vector3 _movement = new Vector3(_horizontal, 0f, _vertical) * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + _movement);
        Rotation(_movement);
    }
    private void Rotation(Vector3 vectorRotation)
    {
        transform.rotation = Quaternion.LookRotation(vectorRotation);
    }
    public void AnimationControll(bool move)
    {
        _animator.SetBool("Go", move);
    }
}
