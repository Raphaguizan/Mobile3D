using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fwdSpeed = 5f;
    public Transform target;
    public float followTargetSpeed = 1f;

    [Header("Compare Tags")]
    public string enemyTag = "Enemy";
    public string finishTag = "WinLine";
    [Header("finish Interface")]
    public GameObject restartScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    private float _posX;
    private bool _canRun;

    private void Start()
    {
        restartScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
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
        if (collision.transform.CompareTag(enemyTag))
        {
            EndGame(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(finishTag))
        {
            EndGame(true);
        }
    }

    public void StartGame()
    {
        _canRun = true;
    }

    private void EndGame(bool victory)
    {
        _canRun = false;

        restartScreen.SetActive(true);
        if (victory) winScreen.SetActive(true);
        else loseScreen.SetActive(true);
    }
}
