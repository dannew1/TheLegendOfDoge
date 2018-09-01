using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShieldSimpleStickMod : ThunderShieldMod {

    public void Initialize()
    {
        modType = 0;
        modPriority = 0;
    }

    public override void ModStart()
    {

    }

    public override void ModUpdate()
    {
        StickToPlayer();
    }

    public override void ModTriggerEnter()
    {

    }

    public override void ModKillThis()
    {

    }

    public override void ModOnDestroy()
    {

    }

    private void StickToPlayer()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
}
