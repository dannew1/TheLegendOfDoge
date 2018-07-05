using UnityEngine;
using System.Collections;

public class DogeHealth : MonoBehaviour
{
    private Doge dogeScript;

    private float maxHealth;
    private float healthRegen;
    private float health;

    private float damageDelay = 3;
    private bool unkillable = false;

    // Use this for initialization
    void Start()
    {
        dogeScript = GetComponent<Doge>();
        SetStats();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DamageDelayCountdown();
        SetStats();
        HealthRegen();
        PlayerDeath();
    }

    private void SetStats()
    {
        maxHealth = dogeScript.baseMaxHp + (dogeScript.hpStat * 100);
        healthRegen = dogeScript.baseHpRegen + (dogeScript.hpRegStat * 2);
    }

    public void EditHealth(float value)
    {
        health += value;
    }

    public void InvunerableDoge()
    {
        unkillable = true;
    }
    public void KillableDoge()
    {
        unkillable = false;
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;
        if (!unkillable)
        {
            if (other_obj.GetComponent<Enemy>() && damageDelay <= 0)
            {
                damageDelay = 100;
                health -= 490;
            }
            else if (other_obj.GetComponent<GuyBullet>() && damageDelay <= 0)
            {
                damageDelay = 100;
                health -= 900;
            }
        }
    }

    private void DamageDelayCountdown()
    {
        if (damageDelay >= -10)
        {
            damageDelay -= Time.deltaTime * 100;
        }
    }
    private void HealthRegen()
    {
        if (health < maxHealth && damageDelay <= 0)
        {
            health += Time.deltaTime * healthRegen;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }
    private void PlayerDeath()
    {
        if (health <= 0)
        {
            dogeScript.DogeIsDead();
        }
    }

    public float ReturnHpValues(int stat)
    {
        if (stat == 1)
        {
            return health;
        }

        //else if (stat == 2)
        //{
        //    return maxHealth;
        //}

        else
        {
            return 0;
        }

    }

}
