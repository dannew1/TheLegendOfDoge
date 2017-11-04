﻿using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public Fireball fireballPrefab;
    private Doge dogeScript;

    private float maxMana;
    private float manaRegen;
    
    private float reloadTime = 0;
    private float shootingDelay;
    private float manaUsage;
    private float fireballSpeed;
    //private float shootingDirection = 2;

    public float mana;

    

    // Use this for initialization
    void Start () {
        dogeScript = GetComponent<Doge>();

        SetStats();
        mana = maxMana;

        shootingDelay = Fireball.reloadTime;
        manaUsage = Fireball.manaUsage;
        fireballSpeed = Fireball.shootingSpeed;
    }

    // Update is called once per frame
    void Update () {
        ShootFireBall();
        SetStats();
        //SetShootingDirection();

        ManaRegen();
        SetMana();
    }

    private void SetStats()
    {
        maxMana = dogeScript.baseMaxMana + (dogeScript.spStat * 10);
        manaRegen = dogeScript.baseManaRegen + (dogeScript.spRegStat * 0.2f);
    }

    private void SetShootingDelay ()
        {
            reloadTime = shootingDelay;
        }

    private void ShootFireBall()
    {
        reloadTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.C) && reloadTime <= 0 && mana > manaUsage)
        {
            Fireball clone = (Fireball)Instantiate(fireballPrefab, transform.position, transform.rotation);
            clone.Initialize();
            if (dogeScript.dogeLookingRight == false)
            {
                clone.setSpeed(-fireballSpeed);
            }
            else if (dogeScript.dogeLookingRight == true)
            {
                clone.setSpeed(fireballSpeed);
            }
            SetShootingDelay();
            mana -= manaUsage;
        }
    }

    //private void SetShootingDirection()
    //{
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        shootingDirection = 1;
    //    }
    //    else if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        shootingDirection = 3;
    //    }
    //    else if (Input.GetKey(KeyCode.LeftArrow) && dogeScript.nonTopSpeed())
    //    {
    //        shootingDirection = 2;
    //    }
    //    else if (Input.GetKey(KeyCode.RightArrow) && dogeScript.nonTopSpeed())
    //    {
    //        shootingDirection = 4;
    //    }
    //}

    private void ManaRegen()
    {
        if (mana < maxMana && reloadTime <= 0)
        {
            mana += Time.deltaTime * manaRegen;
        }
    }
    private void SetMana()
    {
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }
}
