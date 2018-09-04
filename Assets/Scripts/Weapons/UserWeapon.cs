using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserWeapon : Weapon {

    public float manaUsage;
    public float reloadTime;

    public void UpdateStats(float mana, float reload)
    {
        manaUsage += mana;
        reloadTime += reload;
    }

    public abstract void Initialize(GameObject i);
    
    public abstract void KillThis();
}
