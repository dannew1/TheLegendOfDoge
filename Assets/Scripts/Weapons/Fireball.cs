using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fireball : UserWeapon {

    private static float shootingSpeed = 300;
    public List<FireballMod> ActiveModList;
    public List<FireballMod> ModList;

    public override void Initialize(GameObject i)
    {
        damage = 20;
        manaUsage = 200;
        reloadTime = 1.2f;

        StartUp(i);

        foreach (FireballMod mod in ActiveModList)
        {
            mod.GetPlayer(player);
        }
    }

    void Start () {
        //SetSpeed();
        Type0mods();
    }

    void Update () {
        
	}

    public override void KillThis()
    {
        
    }

    private void Type0mods()
    {
        foreach(FireballMod mod in ActiveModList)
        {
            mod.ModStart();
        }
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

    //private void SetSpeed()
    //{
    //    if (dogeScript.dogeLookingRight == false)
    //    {
    //        rigid.velocity = new Vector2(-shootingSpeed, 0);
    //    }
    //    else if (dogeScript.dogeLookingRight == true)
    //
    //    {
    //        rigid.velocity = new Vector2(shootingSpeed, 0);
    //    }
    //}
}
