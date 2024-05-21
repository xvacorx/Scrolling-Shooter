using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : PowerUps
{
    public float damageIncrease = 1f;

    public override void ApplyPowerUp(GameObject player)
    {
        PlayerManager playerScript = player.GetComponent<PlayerManager>();
        if (playerScript != null)
        {
            playerScript.IncreaseDamage(damageIncrease);
        }
    }
}
