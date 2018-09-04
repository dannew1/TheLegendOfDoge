using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShield : UserWeapon {

    public List<ThunderShieldMod> ActiveModList;
    public List<ThunderShieldMod> ModList;

    public override void Initialize(GameObject player)
    {
        damage = 1;
        manaUsage = 2;
        reloadTime = 0;

        foreach(ThunderShieldMod mod in ActiveModList)
        {
            mod.GetPlayer(player);
        }
    }
 
    void Start()
    {
        Type0mods();
    }

    void Update () {
        Type1mods();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            Type2mods();
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            Type3mods();
        }
    }

    public override void KillThis()
    {
        Type4mods();

    }

    void OnDestroy()
    {
        Type5mods();
    }

    private void Type0mods()
    {
        foreach (ThunderShieldMod mod in ActiveModList)
        {
            mod.ModStart();
        }
    }


    private void Type1mods()
    {
        foreach (ThunderShieldMod mod in ActiveModList)
        {
            mod.ModUpdate();
        }
    }

    private void Type2mods()
    {
        foreach (ThunderShieldMod mod in ActiveModList)
        {
            mod.ModTriggerEnter();
        }
    }

    private void Type3mods()
    {
        foreach (ThunderShieldMod mod in ActiveModList)
        {
            mod.ModTriggerExit();
        }
    }

    private void Type4mods()
    {
        foreach (ThunderShieldMod mod in ActiveModList)
        {
            mod.ModKillThis();
        }
    }

    private void Type5mods()
    {
        foreach (ThunderShieldMod mod in ActiveModList)
        {
            mod.ModOnDestroy();
        }
    }
}
