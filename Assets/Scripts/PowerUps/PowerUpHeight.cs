using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeight : PowerUpBase
{
    [Header("Height")]
    public float heightAmount = 3;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        Debug.Log("iniciou powerup");
        PlayerPowerUpManager.PlusHeight(heightAmount);
    }
    protected override void EndPowerUp()
    {
        Debug.Log("terminou powerup");
        PlayerPowerUpManager.PlusHeight(0);
    }
}
