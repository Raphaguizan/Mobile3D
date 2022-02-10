using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Speed")]
    public float SpeedAmount = 18f;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerPowerUpManager.ChangeSpeed(SpeedAmount);
    }
    protected override void EndPowerUp()
    {
        PlayerPowerUpManager.ResetSpeed();
    }
}
