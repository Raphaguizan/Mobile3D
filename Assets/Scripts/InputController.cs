using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float xSpeed = 3f;
    public Vector2 xBoundaries;


    private float _lastMouseXPosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - _lastMouseXPosition);
        }
        _lastMouseXPosition = Input.mousePosition.x;
    }

    public void Move(float dist)
    {
        transform.position += Vector3.right * Time.deltaTime * dist * xSpeed;
        if (transform.position.x > xBoundaries.y) 
            transform.position = new Vector3(xBoundaries.y, transform.position.y, transform.position.z);
        if(transform.position.x < xBoundaries.x)
            transform.position = new Vector3(xBoundaries.x, transform.position.y, transform.position.z);
    }
}
