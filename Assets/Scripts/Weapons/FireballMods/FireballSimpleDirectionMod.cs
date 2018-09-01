using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSimpleDirectionMod : FireballMod
{
    public void Initialize()
    {
        modType = 0;
        modPriority = 0;
    }

    public override void ModStart()
    {
        SetSpeed();
    }

    private void SetSpeed()
    {
        if (dogeScript.dogeLookingRight == false)
        {
            rigid.velocity = new Vector2(-300, 0);
        }
        else if (dogeScript.dogeLookingRight == true)
        
        {
            rigid.velocity = new Vector2(300, 0);
        }
    }

    public override void ModUpdate()
    {

    }

    public override void ModTriggerEnter()
    {

    }
}
