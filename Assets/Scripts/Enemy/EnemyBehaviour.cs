using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Transform _target;
    private float _minDistance = 0.4f;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _target = WayPoints.points[_wavePointIndex];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, _target.position) <= _minDistance)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if(_wavePointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        _wavePointIndex++;
        _target = WayPoints.points[_wavePointIndex];
    }
}
