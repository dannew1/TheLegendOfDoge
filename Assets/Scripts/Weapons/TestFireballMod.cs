using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFireballMod : FireballMod
{
    public void Initialize()
    {
        modtype = 0;
        modPriority = 0;
    }

    public override void ModStart()
    {
        SetSpeed();
    }

    //public void OnTriggerEnter2D(Collider2D collider)
    //{
    //    GameObject other_obj = collider.gameObject;
    //
    //    if (other_obj.GetComponent<Enemy>())
    //    {
    //        Destroy(gameObject);
    //    }
    //}

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
