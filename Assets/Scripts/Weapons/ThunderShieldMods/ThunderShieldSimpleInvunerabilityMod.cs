using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShieldSimpleInvunerabilityMod : ThunderShieldMod {

    public override void Initialize()
    {
        modType = 0;
        modPriority = 0;
    }

    public override void ModStart()
    {
        dogeScript.Invunerablility();
    }

    public override void ModUpdate()
    {

    }

    public override void ModTriggerEnter()
    {

    }

    public override void ModTriggerExit()
    {

    }

    public override void ModKillThis()
    {

    }

    public override void ModOnDestroy()
    {
        dogeScript.DeactivateInvunerability();
    }
}
