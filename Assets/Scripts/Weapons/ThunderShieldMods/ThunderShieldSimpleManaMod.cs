using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShieldSimpleManaMod : ThunderShieldMod {

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
        SetManaUsage();
    }

    public override void ModTriggerEnter()
    {
        hitEnemy = true;
    }

    public override void ModKillThis()
    {

    }

    public override void ModOnDestroy()
    {

    }

    private void SetManaUsage()
    {
        if (hitEnemy)
        {
            hitEnemy = false;
            currentManaUsage = 15;
        }
        else if (!hitEnemy)
        {
            currentManaUsage = 2;
        }
    }
}
