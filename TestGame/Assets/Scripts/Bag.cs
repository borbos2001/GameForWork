using System.Collections.Generic;
using UnityEngine;
public class Bag : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _cubeWheat;
    private List<GameObject> _cubeWheatList = new List<GameObject>();

    private GameObject _bag;

    private void Start()
    {
        _bag = GameObject.Find("Bag");
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
        _cubeWheatList.Add(wheat);
        int ind = _cubeWheatList.LastIndexOf(wheat);
        wheat.transform.position += Vector3.up * _cubeWheat.transform.localScale.y/10 * ind ;
    }
    public void OutBag()
    {

    }
}
