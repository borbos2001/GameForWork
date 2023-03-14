using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.Names
{
    public class Bag : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _map;
        [SerializeField] private GameObject _cubeWheat;
        [SerializeField] private Transform _salePoint;
        [SerializeField] private Sale _sale;
        [SerializeField] private BarController _barController;
        private Stack<GameObject> _cubeWheatStack = new Stack<GameObject>();
        private int _ind = 0;
        private Vector3 _previousBlock;
        private GameObject _bag;

        private void Start()
        {
            _bag = GameObject.Find("BagPoint");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Item" && _ind < GlobalValues.MaximumNumberBlocks)
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
            if(_ind > 0)
            {
                _previousBlock = _cubeWheatStack.Peek().transform.position;
            }
            else
            {
                _previousBlock = _bag.transform.position;
            }
            GameObject wheat = Instantiate(_cubeWheat, _previousBlock + Vector3.up*0.025f, _bag.transform.rotation, _bag.transform);
            _cubeWheatStack.Push(wheat);
            _ind = _cubeWheatStack.Count;
            _barController.ChangeValueBar(_ind);
        }
        public IEnumerator OutBag()
        {
            if (_ind > 0)
            {
                GameObject _currentObject = _cubeWheatStack.Pop();
                _currentObject.transform.SetParent(_map);
                _currentObject.GetComponent<ObjectOffset>().StartMove(true, _salePoint, _currentObject.transform);
                yield return new WaitForSeconds(0.1f);
                --_ind;
                _barController.ChangeValueBar(_ind);
                _sale.Creating—oin();
                StartCoroutine(OutBag());
            }

        }
    }

}
