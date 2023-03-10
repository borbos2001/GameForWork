
using UnityEngine;

public class CMpoint : MonoBehaviour
{
    [SerializeField] private Transform _player;

    void Update()
    {
        transform.position = _player.position;
    }
}
