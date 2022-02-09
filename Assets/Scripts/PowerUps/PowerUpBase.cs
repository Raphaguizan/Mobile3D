using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("PowerUp")]
    public float duration = 3f;

    private void Start()
    {
        timeToDestroy = duration + 1;
    }

    protected override void OnCollet()
    {
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
    }
    protected virtual void EndPowerUp()
    {

    }
}
