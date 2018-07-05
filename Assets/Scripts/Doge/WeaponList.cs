using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour {

    //private Doge dogeScript;

    public Fireball fireballPrefab;
    private Vector2 fireBallReturn;

    public ThunderShield thunderShieldPrefab;
    private Vector2 thunderShieldReturn;

    private ThunderShield activeShield = null;
    private bool keepShieldActive = false;

    private Vector2 zero = new Vector2(0, 0);

    //Return Mana, ReloadTime, EquipedWeapon

    // Use this for initialization
    void Start()
    {
        //dogeScript = GetComponent<Doge>();
        SetReturnValues();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveShots();
        DestroyActiveShots();
    }

    public Vector2 ActivateWeapon(Vector3 shootingStats)
    {
        //(equipedWeapon, mana, reloadTime)
        if (CheckStats(shootingStats))
        {
            if (shootingStats.x == 1)
            {
                ShootFireBall();
                return fireBallReturn;
            }
            if (shootingStats.x == 2)
            {
                ShootThunderShield();
                return thunderShieldReturn;
            }
        }

        ResetActiveWeapons();
        return zero;
    }

    private bool CheckStats(Vector3 shootingStats)
    {
        if (shootingStats.z <= 0)
        {
            if (shootingStats.x == 1 && shootingStats.y >= fireBallReturn.x)
            {
                return true;
            }
            else if (shootingStats.x == 2 && shootingStats.y >= thunderShieldReturn.x)
            {
                return true;
            }
        }

        return false;
    }

    private void SetReturnValues()
    {
        fireballPrefab.Initialize(gameObject);
        fireBallReturn = new Vector2(fireballPrefab.baseManaUsage, fireballPrefab.reloadTime);
    
        thunderShieldPrefab.Initialize(gameObject);
        thunderShieldReturn = new Vector2(thunderShieldPrefab.baseManaUsage, thunderShieldPrefab.reloadTime);
    }

    private void ShootFireBall()
    {
        Fireball clone = (Fireball)Instantiate(fireballPrefab, transform.position, transform.rotation);
        clone.Initialize(gameObject);
    }

    private void ShootThunderShield()
    {
        if (activeShield == null)
        {
            ThunderShield clone = (ThunderShield)Instantiate(thunderShieldPrefab, transform.position, transform.rotation);
            clone.Initialize(gameObject);

            activeShield = clone;
            keepShieldActive = true;
        }
    }

    public void ResetActiveWeapons()
    {
        keepShieldActive = false;
    }

    private void ActiveShots()
    {
        if(activeShield != null)
        {
            thunderShieldReturn = new Vector2(activeShield.manaUsage, activeShield.reloadTime);
        }
    }

    private void DestroyActiveShots()
    {
        if (activeShield != null && keepShieldActive == false)
        {
            thunderShieldReturn = new Vector2(activeShield.baseManaUsage, activeShield.reloadTime);
            Destroy(activeShield.gameObject);
        }
    }
}