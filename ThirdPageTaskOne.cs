using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPageTaskOne : MonoBehaviour
{
    public float startingSpeed;
    public float height;

    private float g = 9.81f;
    private Vector3 _velocity;

    private float _totalDistance;

    private float _currentTime;

    private void Start(){
        transform.position = new Vector3 (0, height, 0);
        _velocity.y = startingSpeed;
    }

    private void Update(){
        _currentTime += Time.deltaTime;

        if (transform.position.y > 0){
            _velocity.y -= g * Time.deltaTime;
        }
        else{
            _velocity.y = 0;
        }
        transform.position += _velocity * Time.deltaTime;
        _totalDistance += _velocity.magnitude * Time.deltaTime;

        Debug.Log("Пройденный путь: " + _totalDistance + ". Времени прошло: " + _currentTime);
    }
}
