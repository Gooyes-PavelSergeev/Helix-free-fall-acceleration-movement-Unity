using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPageTaskTwo : MonoBehaviour
{
    public float t1;
    public float t2;
    public float t3;

    public float A;
    public float B;
    public float C;
    public float D;

    private bool _t2IsCaptured;
    private bool _t3IsCaptured;

    private float _speedX;
    private float _speedY;
    private float _currentAccelerationX;
    private float _currentAccelerationY;
    private float _currentTime;
    private float _timeSinceT1;

    private float _distance;

    public void Start()
    {

    }

    public void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= t2 && !_t2IsCaptured){
            _t2IsCaptured = true;
            Debug.Log("Пройденный путь в момент времени t2: " + _distance);
        }

        if (_currentTime >= t3 && !_t3IsCaptured){
            _t3IsCaptured = true;
            Debug.Log("Величина скорости в момент времени t3: " + Mathf.Sqrt(_speedX * _speedX + _speedY * _speedY));
            Debug.Log("Величина ускорения в момент времени t3: " + Mathf.Sqrt(_currentAccelerationX * _currentAccelerationX + _currentAccelerationY * _currentAccelerationY));
        }


        if (_currentTime >= t1){
            _timeSinceT1 += Time.deltaTime;
            _currentAccelerationX = A + B * _timeSinceT1;
            _currentAccelerationY = C + D * _timeSinceT1;
        }

        _speedX += _currentAccelerationX * Time.deltaTime;
        _speedY += _currentAccelerationY * Time.deltaTime;

        Vector3 tickVelocity = Vector3.right * _speedX * Time.deltaTime + Vector3.up * _speedY * Time.deltaTime;
        float tickDistance = tickVelocity.magnitude;

        transform.position += tickVelocity;
        _distance += tickDistance;

        if (_currentTime > 30){
            Time.timeScale = 0;
        }
    }
}
