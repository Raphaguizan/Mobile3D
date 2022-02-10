using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollect : PowerUpBase
{
    [Header("Collect")]
    public float sizetAmount = 3;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerPowerUpManager.ChangeCollectSize(sizetAmount);
    }
    protected override void EndPowerUp()
    {
        PlayerPowerUpManager.ChangeCollectSize(1);
    }
}
