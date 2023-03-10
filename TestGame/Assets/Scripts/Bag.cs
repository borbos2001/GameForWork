
using System.Collections.Generic;
using UnityEngine;
public class Bag : MonoBehaviour
{
    [SerializeField] private Transform _bag;
    private List<GameObject> _coobWheat = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("wow");
        if(other.tag == "Item")
        {
            other.transform.SetParent(_bag);
            IntoBag(other.gameObject);
        }
    }
    public void IntoBag(GameObject wheat)
    {
        _coobWheat.Add(wheat);
        _coobWheat.LastIndexOf(wheat);
        wheat.GetComponent<TakeLoot>().StartMove(true,_bag,wheat.transform);
    }
    public void OutBag()
    {

    }
}
