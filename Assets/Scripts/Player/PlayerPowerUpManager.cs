using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using DG.Tweening;

public class PlayerPowerUpManager : Singleton<PlayerPowerUpManager>
{
    #region SetUp
    private Vector3 _initialPos;
    private void Start()
    {
        _initialPos = transform.position;
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
        Instance.CollectCollider.transform.localScale = Instance.CollectCollider.transform.localScale * amount;
    }

    #endregion
}
