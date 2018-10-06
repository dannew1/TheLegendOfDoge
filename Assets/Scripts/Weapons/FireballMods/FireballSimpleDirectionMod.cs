using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSimpleDirectionMod : FireballMod
{
    public override void Initialize()
    {
        modType = 0;
        modPriority = 0;
    }

    public override void ModStart()
    {
        SetSpeed();
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

    }

    private void SetSpeed()
    {
        if (dogeScript.dogeLookingRight == false)
        {
            rigid.velocity = new Vector2(-100, 0);
        }
        else if (dogeScript.dogeLookingRight == true)

        {
            rigid.velocity = new Vector2(100, 0);
        }
    }
}