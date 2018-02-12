using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    private Doge dogeScript;
    private WeaponList weaponScript;

    private int equipedWeapon = 1;
    private float reloadTime = 0;
    private float baseReload;
    private float mana;
    private bool readyToFire = true;
    private float maxMana;
    private float manaRegen;
    
    //Keep track off MaxMana, ManaRegen, reload
    //Return?

    // Use this for initialization
    void Start () {
        dogeScript = GetComponent<Doge>();
        weaponScript = GetComponent<WeaponList>();

        SetStats();
        mana = maxMana;
    }

    // Update is called once per frame
    void Update () {
        SetStats();

        ChangeWeapon();
        UseWeapon();

        CountDownReloadTime();
        ReadyFire();
        ManaRegen();
    }

    private void SetStats()
    {
        maxMana = dogeScript.baseMaxMana + (dogeScript.spStat * 100);
        manaRegen = dogeScript.baseManaRegen + (dogeScript.spRegStat * 2);
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(equipedWeapon == 1)
            {
                equipedWeapon = 2;
            }
            else if (equipedWeapon == 2)
            {
                equipedWeapon = 1;
            }
        }
    }

    private void UseWeapon()
    {
        if (Input.GetKey(KeyCode.C) && readyToFire == true)
        {
            Vector2 re;
            re = weaponScript.ActivateWeapon(new Vector3(equipedWeapon, mana, reloadTime));
            if (re.x == 0 || re.y != 0)
            {
                readyToFire = false;
            }
            mana -= re.x;
            reloadTime += re.y;
            baseReload = re.y;
        }
    }

    private void CountDownReloadTime()
    {
        if (reloadTime > 0)
        {
            reloadTime -= Time.deltaTime;
        }
        if (reloadTime < 0)
        {
            reloadTime = 0;
        }
    }

    private void ReadyFire()
    {
        if(reloadTime <= 0 && mana > 0 && !Input.GetKey(KeyCode.C))
        {
            readyToFire = true;
        }
    }

    private void ManaRegen()
    {
        if (mana < maxMana && reloadTime <= 0)
        {
            mana += Time.deltaTime * manaRegen;
        }

        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }

    public float ReturnMpValues(int stat)
    {
        if (stat == 1)
        {
            return mana;
        }

        else if (stat == 2)
        {
            return equipedWeapon;
        }

        else
        {
            return 0;
        }

    }

    public Vector2 ReturnRelaod()
    {
        return new Vector2(reloadTime, baseReload);
    }
}
