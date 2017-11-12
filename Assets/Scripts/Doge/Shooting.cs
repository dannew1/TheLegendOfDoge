using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    private Doge dogeScript;
    private WeaponList weaponScript;

    private int equipedWeapon = 1;
    private float reloadTime = 0;
    public float mana;

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
        ManaRegen();
        SetMana();
    }

    private void SetStats()
    {
        maxMana = dogeScript.baseMaxMana + (dogeScript.spStat * 10);
        manaRegen = dogeScript.baseManaRegen + (dogeScript.spRegStat * 0.2f);
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
        if (Input.GetKey(KeyCode.C))
        {
            Vector2 re;
            re = weaponScript.ActivateWeapon(new Vector3(equipedWeapon, mana, reloadTime));
            mana -= re.x;
            reloadTime += re.y;
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
        Debug.Log(reloadTime);
    }

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
