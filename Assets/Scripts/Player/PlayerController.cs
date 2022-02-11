using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float fwdSpeed = 9f;
    public Transform target;
    public float followTargetSpeed = 1f;
    [Header("Animation")]
    public AnimationManager animationManager;
    private float _baseSpeedToAnimation = 9f;

    [Header("Compare Tags")]
    public string enemyTag = "Enemy";
    public string finishTag = "WinLine";
    [Header("finish Interface")]
    public GameObject restartScreen;
    public GameObject winScreen;
    public GameObject winButton;
    public GameObject loseScreen;
    public GameObject loseButton;

    private float _posX;
    private bool _canRun;

    private void Start()
    {
        restartScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        loseButton.SetActive(false);
        winButton.SetActive(false);
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
            collision.transform.DOMoveZ(1f, .5f).SetRelative();
            animationManager.Play(AnimationType.DIE);
            EndGame(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(finishTag))
        {
            animationManager.Play(AnimationType.IDLE);
            EndGame(true);
        }
    }
    public void CalculateRunSpeed()
    {
        animationManager.Play(AnimationType.RUN, fwdSpeed / _baseSpeedToAnimation);
    }

    public void ChangeSpeed(float value)
    {
        fwdSpeed = value;
        CalculateRunSpeed();
    }

    public void StartGame()
    {
        _canRun = true;

        LoadGame();
        CalculateRunSpeed();
    }

    public void LoadGame()
    {
        Vector3 restarPos = Vector3.zero;
        restarPos.y = .5f;
        transform.position = restarPos;
    }

    private void EndGame(bool victory)
    {
        _canRun = false;

        restartScreen.SetActive(true);
        if (victory)
        {
            loseScreen.SetActive(false);
            loseButton.SetActive(false);
            winScreen.SetActive(true);
            winButton.SetActive(true);
        }
        else
        {
            winScreen.SetActive(false);
            winButton.SetActive(false);
            loseScreen.SetActive(true);
            loseButton.SetActive(true);
        }
    }
}
