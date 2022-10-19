using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPageTaskTwo : MonoBehaviour
{
    public float acceleration;
    public float speed;
    public float radius;
    public float pitch;
 
    private Vector3 _rotatePoint;

    private Vector3 _previousPosition;
    private float _totalDistance;

    private float _currentTime;
    public float t;
    public float t1;

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
            transform.RotateAround(_rotatePoint, Vector3.right, speed / (2 * Mathf.PI * radius) * 360 * Time.deltaTime);
            Vector3 forwardMovementVelocity = Vector3.right * pitch / ((2 * Mathf.PI * radius) / speed) * Time.deltaTime;
            transform.position += forwardMovementVelocity;
            _rotatePoint += forwardMovementVelocity;
            speed += acceleration * Time.deltaTime;
        }

        float stepDistance = Vector3.Distance(transform.position, _previousPosition);
        _previousPosition = transform.position;

        _totalDistance += stepDistance;

        if (_currentTime >= t1 && !_coordIsPrinted){
            Debug.Log("Пройденный путь: " + _totalDistance + ". Прошло времени: " + _currentTime + ". Текущая координата: " + transform.position);
            _coordIsPrinted = true;
        }
    }
}
