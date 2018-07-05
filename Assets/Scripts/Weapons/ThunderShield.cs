using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShield : Weapon {

    public float manaUsage;
    private bool hitEnemy;

    public void Initialize(GameObject i)
    {
        damage = 1;
        baseManaUsage = 2;
        manaUsage = 2;
        reloadTime = 0;

        StartUp(i);
    }

    void Start () {
        DamageResist();
	}
	
	void Update () {
        StickToPlayer();
        SetManaUsage();
    }

    private void OnDestroy()
    {
        NoDamageResist();
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
            Debug.Log("hi");
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
