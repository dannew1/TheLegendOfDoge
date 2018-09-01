using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fireball : UserWeapon {

    public List<FireballMod> ActiveModList;
    public List<FireballMod> ModList;

    public override void Initialize(GameObject player)
    {
        damage = 20;
        manaUsage = 200;
        reloadTime = 1.2f;

        foreach (FireballMod mod in ActiveModList)
        {
            mod.GetPlayer(player);
        }
    }



    void Start () {
        Type0mods();
    }

    void Update () {
        
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            Type1mods();
        }
    }

    public override void KillThis()
    {
        
    }

    void OnDestroy()
    {

    }




    private void Type0mods()
    {
        foreach(FireballMod mod in ActiveModList)
        {
            mod.ModStart();
        }
    }

    private void Type1mods()
    {
        foreach(FireballMod mod in ActiveModList)
        {
            mod.ModTriggerEnter();
        }
    }


}
