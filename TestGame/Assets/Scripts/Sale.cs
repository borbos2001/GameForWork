
using UnityEngine;

public class Sale : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private GameObject _coinPref;
    [SerializeField] private Transform _canvas;
    [SerializeField] private Transform _salePoint;
    [SerializeField] private Transform _coin—ounter;
    private Vector2 _screenPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(_bag.OutBag());
        }
    }
    public void Creating—oin ()
    {
        _screenPos = Camera.main.WorldToScreenPoint(_salePoint.position);
        GameObject _coin = Instantiate(_coinPref, _screenPos , Quaternion.identity,_canvas);
        _coin.GetComponent<Coin>().StartMoving(true, _coin—ounter.position);
    }
}
