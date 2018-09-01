using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShieldSimpleInvunerabilityMod : ThunderShieldMod {

    public void Initialize()
    {
        modType = 0;
        modPriority = 0;
    }

    public override void ModStart()
    {
        DamageResist();
    }

    public override void ModUpdate()
    {

    }

    public override void ModTriggerEnter()
    {

    }

    public override void ModKillThis()
    {

    }

    public override void ModOnDestroy()
    {
        NoDamageResist();
    }

    private void DamageResist()
    {
        dogeScript.Invunerablility();
    }

    private void NoDamageResist()
    {
        dogeScript.DeactivateInvunerability();
    }
}
