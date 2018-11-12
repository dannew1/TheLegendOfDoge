using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fireball : UserWeapon {

    public List<FireballMod> ActiveModList;
    public List<FireballMod> ModList;

    public override void Initialize(GameObject player)
    {
        damage = 10;
        manaUsage = 400;
        reloadTime = 0.6f;

        foreach (FireballMod mod in ActiveModList)
        {
            mod.GetPlayer(player);
        }
    }


    void Start () {
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
        foreach(FireballMod mod in ActiveModList)
        {
            mod.ModStart();
        }
    }

    private void Type1mods()
    {
        foreach(FireballMod mod in ActiveModList)
        {
            mod.ModUpdate();
        }
    }

    private void Type2mods()
    {
        foreach (FireballMod mod in ActiveModList)
        {
            mod.ModTriggerEnter();
        }
    }

    private void Type3mods()
    {
        foreach (FireballMod mod in ActiveModList)
        {
            mod.ModTriggerExit();
        }
    }

    private void Type4mods()
    {
        foreach (FireballMod mod in ActiveModList)
        {
            mod.ModKillThis();
        }
    }

    private void Type5mods()
    {
        foreach (FireballMod mod in ActiveModList)
        {
            mod.ModOnDestroy();
        }
    }


}
