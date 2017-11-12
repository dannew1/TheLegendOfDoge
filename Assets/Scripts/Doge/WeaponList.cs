using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour {

    private Doge dogeScript;

    public Fireball fireballPrefab;
    private Vector2 fireBallReturn;

    public ThunderShield thunderShieldPrefab;
    private ThunderShield activeShield = null;
    private Vector2 thunderShieldReturn;

    private Vector2 zero = new Vector2(0, 0);

    //Return Mana, ReloadTime, EquipedWeapon
    //CheckStats

    // Use this for initialization
    void Start()
    {
        dogeScript = GetComponent<Doge>();
        SetReturnValues();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveShots();
    }

    public Vector2 ActivateWeapon(Vector3 shootingStats)
    {
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
            else
            {
                return zero;
            }
        }
        else
        {
            return zero;
        }
    }

    private bool CheckStats(Vector3 shootingStats)
    {
        if (shootingStats.x == 1 && shootingStats.y >= 0 && shootingStats.z <= 0)
        {
            return true;
        }
        else if (shootingStats.x == 2 && shootingStats.y >= 0 && shootingStats.z <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ShootFireBall()
    {
        Fireball clone = (Fireball)Instantiate(fireballPrefab, transform.position, transform.rotation);
        clone.Initialize();
        if (dogeScript.dogeLookingRight == false)
        {
            clone.setSpeed(-1);
        }
        else if (dogeScript.dogeLookingRight == true)
        {
            clone.setSpeed(1);
        }
    }

    private void ShootThunderShield()
    {
        if (activeShield == null)
        {
            ThunderShield clone = (ThunderShield)Instantiate(thunderShieldPrefab, transform.position, transform.rotation);
            clone.SetPlayer(gameObject);
            activeShield = clone;
        }
    } 

    private void ActiveShots()
    {
        if (activeShield != null && Input.GetKey(KeyCode.C) == false)
        {
            Destroy(activeShield.gameObject);
        }
    }

    private void SetReturnValues()
    {
        fireBallReturn = new Vector2(Fireball.manaUsage, Fireball.reloadTime);
        thunderShieldReturn = new Vector2(ThunderShield.manaUsage, ThunderShield.reloadTime);
    }
}