
using UnityEngine;

public class Scythe : MonoBehaviour
{
    private Wheat _wheat;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "harvest")
        {
            Debug.Log("dad");
            _wheat =  other.GetComponent<Wheat>();
            _wheat.Harvest();
        }        
    }
}
