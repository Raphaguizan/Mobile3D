using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fwdSpeed = 5f;
    public Transform target;
    public float followTargetSpeed = 1f;

    [Header("Compare Tags")]
    public string EnemyTag = "Enemy";

    private float _posX;
    private bool _canRun;

    private void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (!_canRun) return;

        transform.Translate(Vector3.forward * Time.deltaTime * fwdSpeed);
        _posX = Mathf.Lerp(transform.position.x, target.position.x, followTargetSpeed * Time.deltaTime);
        transform.position = new Vector3(_posX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(EnemyTag))
        {
            EndGame();
        }
    }


    private void StartGame()
    {
        _canRun = true;
    }

    private void EndGame()
    {
        _canRun = false;
    }
}
