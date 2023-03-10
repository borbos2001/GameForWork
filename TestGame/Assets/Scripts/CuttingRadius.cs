using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingRadius : MonoBehaviour
{
    [SerializeField] private GameObject _scythe;
    [SerializeField] private Animator _playerAnimator;
    bool _cut = false;

    private void OnTriggerStay(Collider other)
    {
        if (_cut == false && other.tag == "harvest")
        {
            _playerAnimator.SetBool("ÑloseWheat", true);
            StartCoroutine(TimeCut());
        }
    }
    private IEnumerator TimeCut()
    {
        _cut = true;
        _scythe.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        _scythe.SetActive(false);
        _cut = false;
        _playerAnimator.SetBool("ÑloseWheat", false);
    }
}
