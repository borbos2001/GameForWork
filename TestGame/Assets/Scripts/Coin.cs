
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector2 _endPoint;
    private bool _canMove = false;
    private float _distance,_maxDistace;
    [SerializeField] private float _speed;
    public void StartMoving(bool canMove, Vector2 endPoint)
    {
        _endPoint = endPoint;
        _canMove = canMove;
        _maxDistace = Vector2.Distance(transform.position, _endPoint);
    }
    private void FixedUpdate()
    {
        if (_canMove == true)
        {
            MovingCoin();
        }
    }

    private void MovingCoin()
    {
        _speed += _speed/50;
        transform.position = Vector2.MoveTowards(transform.position, _endPoint, _speed * Time.deltaTime);
        _distance = Vector2.Distance(transform.position, _endPoint);
        float _scale = (_maxDistace - _distance) / _maxDistace;
        gameObject.transform.localScale = new Vector3(_scale, _scale, _scale);
        if (_distance < 1)
        {
            Destroy(gameObject);

        }
    }

}
