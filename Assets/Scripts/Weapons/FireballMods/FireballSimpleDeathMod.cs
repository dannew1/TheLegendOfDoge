using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSimpleDeathMod : FireballMod {

    public void Initialize()
    {
        modType = 1;
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
        Destroy(gameObject);
    }
}
