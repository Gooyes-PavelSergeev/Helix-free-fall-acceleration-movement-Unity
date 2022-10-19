using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPageTaskThree : MonoBehaviour
{
    public float A;
    public float B;
    private float _acceleration;
    public float speed;
    public float radius;
    public float pitch;
 
    private Vector3 _rotatePoint;

    private Vector3 _previousPosition;
    private float _totalDistance;

    private float _currentTime;
    private float _timeSinceT;
    public float t;

    private bool _coordIsPrinted;
 
    void Start()
    {
        _rotatePoint = transform.position + new Vector3 (0, radius, 0);
        _previousPosition = transform.position;
    }

    void Update() 
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= t){
            _timeSinceT += Time.deltaTime;
            transform.RotateAround(_rotatePoint, Vector3.right, speed / (2 * Mathf.PI * radius) * 360 * Time.deltaTime);
            Vector3 forwardMovementVelocity = Vector3.right * pitch / ((2 * Mathf.PI * radius) / speed) * Time.deltaTime;
            transform.position += forwardMovementVelocity;
            _rotatePoint += forwardMovementVelocity;
            _acceleration = A + B * _timeSinceT;
            speed += _acceleration * Time.deltaTime;
        }

        float stepDistance = Vector3.Distance(transform.position, _previousPosition);
        _previousPosition = transform.position;

        _totalDistance += stepDistance;

        Debug.Log("Пройденный путь: " + _totalDistance + ". Прошло времени: " + _currentTime);
    }
}
