using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedPowerUp : PowerUps
{
    public float attackSpeedIncrease = 0.1f;

    public override void ApplyPowerUp(GameObject player)
    {
        PlayerManager playerScript = player.GetComponent<PlayerManager>();
        if (playerScript != null)
        {
            playerScript.IncreaseAttackSpeed(attackSpeedIncrease);
        }
    }
}