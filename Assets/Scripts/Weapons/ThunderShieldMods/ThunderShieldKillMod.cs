﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShieldKillMod : ThunderShieldMod {

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

    }

    public override void ModTriggerExit()
    {

    }

    public override void ModKillThis()
    {
        Destroy(gameObject);
    }

    public override void ModOnDestroy()
    {

    }
}
