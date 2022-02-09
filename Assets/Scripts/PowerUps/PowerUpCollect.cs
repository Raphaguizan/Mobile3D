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
        Debug.Log("iniciou powerup");
        PlayerPowerUpManager.ChangeCollectSize(sizetAmount);
    }
    protected override void EndPowerUp()
    {
        Debug.Log("terminou powerup");
        PlayerPowerUpManager.PlusHeight(1);
    }
}
