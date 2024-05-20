using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUps
{
    public float healthIncrease = 20f;

    public override void ApplyPowerUp(GameObject player)
    {
        PlayerManager playerScript = player.GetComponent<PlayerManager>();
        if (playerScript != null)
        {
            playerScript.IncreaseHealth(healthIncrease);
        }
    }
}
