using System.Collections;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [SerializeField] private float _maxTime = 10f;
    [SerializeField] private GameObject _drop;
    private Animator _animationGrow;

    private void Start()
    {
        _animationGrow = gameObject.GetComponent<Animator>();
        StartCoroutine(TimeToGrow());
    }

    public void Harvest()
    {
        GameObject _loot = Instantiate(_drop, transform.position + Vector3.up *0.1f, Quaternion.identity);
        StartCoroutine(TimeToGrow());
    }
    private IEnumerator TimeToGrow()
    {
        gameObject.tag = "Untagged";
        _animationGrow.SetTrigger("Grow");
        yield return new WaitForSeconds(_maxTime);
        gameObject.tag = "harvest";

    }

}
