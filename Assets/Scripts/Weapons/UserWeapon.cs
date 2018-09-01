using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserWeapon : Weapon {

    public float manaUsage;
    public float reloadTime;

    //protected GameObject player;
    //protected Doge dogeScript;
    //protected Rigidbody2D rigid;
    //
    //protected void StartUp(GameObject doge)
    //{
    //    rigid = GetComponent<Rigidbody2D>();
    //    player = doge;
    //    dogeScript = player.GetComponent<Doge>();
    //}

    public void UpdateStats(float mana, float reload)
    {
        manaUsage = mana;
        reloadTime = reload;
    }

    public abstract void Initialize(GameObject i);
    
    public abstract void KillThis();
}
