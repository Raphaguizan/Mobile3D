using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using DG.Tweening;

public class PlayerPowerUpManager : Singleton<PlayerPowerUpManager>
{
    #region SetUp
    [Header("Setup")]
    public PlayerController player;

    private Vector3 _initialPos;
    private void Start()
    {
        _initialPos = transform.position;
        _initialSpeed = player.fwdSpeed;
    }

    public static Vector3 GetPos()
    {
        return Instance.transform.position;
    }
    #endregion

    #region Height
    [Header("Height")]
    public float animationDuration = 1f;
    public Ease animationEase = Ease.InExpo;


    public static void PlusHeight(float valueAmount)
    {
        Instance.transform.DOMoveY(Instance._initialPos.y + valueAmount, Instance.animationDuration).SetEase(Instance.animationEase);
    }
    #endregion

    #region Collect
    [Header("Collect")]
    public GameObject CollectCollider;

    public static void ChangeCollectSize(float amount)
    {
        Instance.CollectCollider.transform.localScale = Vector3.one * amount;
    }

    #endregion

    #region Speed
    private float _initialSpeed;

    public static void ChangeSpeed(float amount)
    {
        Instance.player.fwdSpeed = amount;
    }
    public static void ResetSpeed()
    {
        Instance.player.fwdSpeed = Instance._initialSpeed;
    }

    #endregion
}
