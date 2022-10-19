using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPageTaskOne : MonoBehaviour
{
    public float t1;
    public float t2;
    public float t3;

    public float A;
    public float B;

    private bool _t2IsCaptured;
    private bool _t3IsCaptured;

    private float _speed;
    private float _currentAcceleration;
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
            Debug.Log("Величина скорости в момент времени t3: " + _speed);
            Debug.Log("Величина ускорения в момент времени t3: " + _currentAcceleration);
        }


        if (_currentTime >= t1){
            _timeSinceT1 += Time.deltaTime;
            _currentAcceleration = A + B * _timeSinceT1;
        }

        _speed += _currentAcceleration * Time.deltaTime;

        Vector3 tickVelocity = Vector3.right * _speed * Time.deltaTime;
        float tickDistance = tickVelocity.magnitude;

        transform.position += tickVelocity;
        _distance += tickDistance;

        if (_currentTime > 30){
            Time.timeScale = 0;
        }
    }
}
