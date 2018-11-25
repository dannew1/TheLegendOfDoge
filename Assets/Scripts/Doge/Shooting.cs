using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    private Doge dogeScript;
    private WeaponList weaponScript;

    private float fireballReloadTime = 0;
    private float fireballBaseReload;

    private float thundershieldReloadTime = 0;
    private float thundershieldBaseReload;

    private bool usingFireball = false;
    private bool usingThundershield = false;

    private float mana;
    private float maxMana;
    private float manaRegen;

    private bool readyToFireball = true;
    private bool readyToThundershield = true;

    private float regenDelay = 0;
    private float baseRegenDelay = 3;

    private float fireballTimer = 0;
    private float thunderShieldTimer = 0;
    private float frameDelay = 0.03f;

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

        UseFireball();
        UseThundershield();

        fireballReloadTime = CountDownReloadTime(fireballReloadTime);
        thundershieldReloadTime = CountDownReloadTime(thundershieldReloadTime);

        ReadyFireball();
        ReadyThunderShield();

        ManaRegen();
    }

    private void SetStats()
    {
        //Check this??
        maxMana = dogeScript.baseMaxMana + (dogeScript.spStat * 100);
        manaRegen = dogeScript.baseManaRegen + (dogeScript.spRegStat * 2);
    }

    private void UseFireball()
    {
        if(fireballTimer > 0)
        {
            fireballTimer -= Time.deltaTime;
        }

        if (fireballTimer <= 0)
        {
            if (Input.GetKey(KeyCode.C) && readyToFireball == true)
            {
                usingFireball = true;

                Vector2 re;
                re = weaponScript.ShootFireball(mana);

                mana -= re.x;
                fireballReloadTime += re.y;
                fireballBaseReload = re.y;
            }
            else if (usingFireball)
            {
                usingFireball = false;
                weaponScript.KillFireball();
            }
            fireballTimer = frameDelay;
        }
    }

    public void NotEnoughForFireball()
    {
        usingFireball = false;
        readyToFireball = false;
    }

    private void ReadyFireball()
    {
        if(fireballReloadTime <= 0 && mana > 0 && !Input.GetKey(KeyCode.C))
        {
            readyToFireball = true;
        }
    }

    private void UseThundershield()
    {
        if (thunderShieldTimer > 0)
        {
            thunderShieldTimer -= Time.deltaTime;
        }

        if (thunderShieldTimer <= 0)
        {
            if (Input.GetKey(KeyCode.V) && readyToThundershield == true)
            {
                usingThundershield = true;

                Vector2 re;
                re = weaponScript.ShootThundershield(mana);

                mana -= re.x;
                thundershieldReloadTime += re.y;
                thundershieldBaseReload = re.y;
            }
            else if (usingThundershield)
            {
                usingThundershield = false;
                weaponScript.KillThundershield();
            }
            thunderShieldTimer = frameDelay;
        }
    }

    public void NotEnoughForThundershield()
    {
        usingThundershield = false;
        readyToThundershield = false;
    }

    private void ReadyThunderShield()
    {
        if (thundershieldReloadTime <= 0 && mana > 0 && !Input.GetKey(KeyCode.V))
        {
            readyToThundershield = true;
        }
    }

    private float CountDownReloadTime(float reloadTime)
    {
        float newReload = reloadTime;

        if (reloadTime > 0)
        {
            newReload -= Time.deltaTime;
        }

        if (reloadTime < 0)
        {
            newReload = 0;
        }

        return newReload;
    }

    public void SetRegenDelay()
    {
        regenDelay = baseRegenDelay;
    }

    private void ManaRegen()
    {
        if(regenDelay > 0)
        {
            regenDelay -= Time.deltaTime;
        }

        if (mana < 0)
        {
            mana = 0;
        }

        if (mana < maxMana && regenDelay <= 0)
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
            return maxMana;
        }

        else
        {
            return 0;
        }

    }

    public Vector2 ReturnRelaod(int weapon)
    {
        if (weapon == 1)
        {
            return new Vector2(fireballReloadTime, fireballBaseReload);
        }
        else if (weapon == 2)
        {
            return new Vector2(thundershieldReloadTime, thundershieldBaseReload);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }
}
