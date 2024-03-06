using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        var targetPos = _target.position + _offset;
        var disstance = Vector3.Distance(targetPos, transform.position);
        var speed = _speed * (disstance / 2) * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed);
    }
}
