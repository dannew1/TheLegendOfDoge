using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShieldSimpleManaMod : ThunderShieldMod {

    public override void Initialize()
    {
        modType = 0;
        modPriority = 0;
    }

    public override void ModStart()
    {

    }

    public override void ModUpdate()
    {

    }

    public override void ModTriggerEnter()
    {
        changeManaUsage = 13;
    }

    public override void ModTriggerExit()
    {
        changeManaUsage = -13;
    }

    public override void ModKillThis()
    {

    }

    public override void ModOnDestroy()
    {

    }
}
