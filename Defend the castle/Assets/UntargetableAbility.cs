using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntargetableAbility : Ability
{
    [SerializeField] private float untargetableTime;

    private const string playerTag = "Player";
    private const string playerInvisibleTag = "InvisiblePlayer";

    private float currentUntargetableTime;

    private bool untargetable;

    private PlayerController player;

    public override void HandleAbility(PlayerController player)
    {
        base.HandleAbility(player);

        this.player = player;

        untargetable = true;

        currentUntargetableTime = 0;
        
        player.Invisible = true;
    }

    public override void Update()
    {
        base.Update();

        if (untargetable)
        {
            currentUntargetableTime += Time.deltaTime;

            if (currentUntargetableTime >= untargetableTime)
            {
                untargetable = false;
                player.Invisible = false;
                currentUntargetableTime = 0;
            }
        }
    }
}
