using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fwdSpeed = 5f;
    public Transform target;
    public float followTargetSpeed = 1f;

    private float _posX;

    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * fwdSpeed);
        _posX = Mathf.Lerp(transform.position.x, target.position.x, followTargetSpeed * Time.deltaTime);
        transform.position = new Vector3(_posX, transform.position.y, transform.position.z);
    }
}
