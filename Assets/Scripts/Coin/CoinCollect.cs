using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinCollect : ItemCollectableBase
{
    public float animationSpeed = 1f;
    public float minDist = 1f;
    protected override void Collect()
    {
        OnCollet();
        StartCoroutine(CollectAnimation());
    }

    IEnumerator CollectAnimation()
    {
        while (Vector3.Distance(transform.position, PlayerPowerUpManager.GetPos()) > minDist)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, PlayerPowerUpManager.GetPos(), animationSpeed * Time.deltaTime);
        }
        DisableObj();
    }
}
