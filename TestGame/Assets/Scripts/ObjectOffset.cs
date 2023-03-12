
using UnityEngine;

public class ObjectOffset : MonoBehaviour
{
    private Transform _startPoint;
    private Transform _endPoint;
    private bool _take = false;
    [SerializeField] private float height = 5f;
    [SerializeField] private float speed = 5f;
    private float distance;
    private float startTime;
    private void Update()
    {
        if (_take)
        {
            distance = Vector3.Distance(gameObject.transform.position, _endPoint.position);
            MoveItem();
        }
    }
    private void MoveItem()
    {
        if (distance >= 0.1f)
        {
            float timeElapsed = (Time.time - startTime) * speed;
            float normalizedDistance = timeElapsed / distance;
            Vector3 pointA = Vector3.Lerp(_startPoint.position, _endPoint.position, normalizedDistance);
            Vector3 pointB = pointA + Vector3.up * height;
            gameObject.transform.position = ParabolicMovementEquation(pointA, pointB, _endPoint.position, normalizedDistance);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    private Vector3 ParabolicMovementEquation(Vector3 pointA, Vector3 pointB, Vector3 pointC, float t)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 pointP = uu * pointA;
        pointP += 2f * u * t * pointB;
        pointP += tt * pointC;
        return pointP;
    }
    public void StartMove(bool take , Transform endPoint , Transform startPoint)
    {
        _take = take;
        _endPoint = endPoint;
        _startPoint = startPoint;
        startTime = Time.time;
    }

}
