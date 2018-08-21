using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShield : UserWeapon {

    private bool hitEnemy;

    public override void Initialize(GameObject i)
    {
        damage = 1;
        manaUsage = 2;
        reloadTime = 0;

        StartUp(i);
    }

    void Start()
    {
        DamageResist();
    }

    void Update () {
        StickToPlayer();
        SetManaUsage();
    }

    public override void KillThis()
    {
        NoDamageResist();
        Destroy(gameObject);
    }






    private void StickToPlayer()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }

    private void SetManaUsage()
    {
        if(hitEnemy)
        {
            hitEnemy = false;
            manaUsage = 15;
        }
        else if (!hitEnemy)
        {
            manaUsage = 2;
        }
    }


    public void OnTriggerStay2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            hitEnemy = true;
        }
    }

    private void DamageResist()
    {
        dogeScript.Invunerablility();
    }
    private void NoDamageResist()
    {
        dogeScript.DeactivateInvunerability();
    }
}
