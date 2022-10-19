using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPageTaskTwo : MonoBehaviour
{
    private float _speedX;
    private float _speedY;
    public float height;
    public float acceleration;
    public float angleInDegrees;
    private float _groundingSpeed;
    private float _averageSpeed;
    private float _totalSpeed;

    private float g;
    private Vector3 _velocity;

    public float t;
    private float _currentTime;

    private float _flyDistance;

    private bool _isGrounded;
    private bool _isPrinted;
    private bool _accelerationIsGiven;

    private int _numberOfIterations;

    private void Start(){
        transform.position = new Vector3 (0, height, 0);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= t)
        {
            if (!_accelerationIsGiven){
                _velocity.x = acceleration * Mathf.Cos(angleInDegrees * Mathf.Deg2Rad);
                _velocity.y = acceleration * Mathf.Sin(angleInDegrees * Mathf.Deg2Rad);
                g = 9.81f;
                _accelerationIsGiven = true;
            }

            if (transform.position.y > 0)
            {
                _velocity.y -= g * Time.deltaTime;
                _totalSpeed += _velocity.magnitude;
                _numberOfIterations++;
            }

            else
            {
                _isGrounded = true;
                _flyDistance = Vector3.Distance(new Vector3 (0, height, 0), transform.position);
                _averageSpeed = _totalSpeed / _numberOfIterations;
                _groundingSpeed = _velocity.magnitude;
                _velocity = Vector3.zero;
            }
            transform.position += _velocity * Time.deltaTime;
        }

        if (_isGrounded && !_isPrinted)
        {
            _isPrinted = true;
            Debug.Log("Дальность полета: " + _flyDistance + ". Времени прошло: " + (_currentTime - t) + ". Скорость при приземлении: " + _groundingSpeed
                    + ". Средняя скорость в полете: " + _averageSpeed);
        }
    }
}
