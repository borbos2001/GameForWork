using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bag : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _map;
    [SerializeField] private GameObject _cubeWheat;
    [SerializeField] private Transform _salePoint;
    [SerializeField] private Sale _sale;
    private Stack<GameObject> _cubeWheatStack = new Stack<GameObject>();
    private int _ind;

    private GameObject _bag;

    private void Start()
    {
        _bag = GameObject.Find("BagPoint");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            other.tag = "Untagged";
            other.transform.SetParent(_player);
            GameObject wheat = other.gameObject;
            wheat.GetComponent<ObjectOffset>().StartMove(true, _player, wheat.transform);
            IntoBag();
        }
    }
    public void IntoBag()
    {
        GameObject wheat = Instantiate(_cubeWheat, _bag.transform.position, _bag.transform.rotation,_bag.transform);
        _cubeWheatStack.Push(wheat);
        _ind = _cubeWheatStack.Count;
        wheat.transform.position += Vector3.up * _cubeWheat.transform.localScale.y/10 * _ind ;
    }
    public IEnumerator OutBag()
    {
        if (_ind > 0)
        {
            GameObject _currentObject = _cubeWheatStack.Pop();
            _currentObject.transform.SetParent(_map);
            _currentObject.GetComponent<ObjectOffset>().StartMove(true, _salePoint, _currentObject.transform);
            yield return new WaitForSeconds(0.5f);
            --_ind;
            _sale.Creating—oin();
            StartCoroutine(OutBag());
        }
        
    }
}
