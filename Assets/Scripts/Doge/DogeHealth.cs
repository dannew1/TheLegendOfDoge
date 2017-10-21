﻿using UnityEngine;
using System.Collections;

public class DogeHealth : MonoBehaviour
{
    private Doge DogeScript;

    public float maxHealth = 100;
    public float healthRegen = 3;
    private float currentHealthRegen;

    private float damageDelay = 3;

    public float health;

    // Use this for initialization
    void Start()
    {
        DogeScript = GetComponent<Doge>();
        health = maxHealth + (DogeScript.hpStat * 10);
        currentHealthRegen = healthRegen + (DogeScript.hpRegStat * 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        DamageDelayCountdown();
        HealthRegen();
        SetHealth();
        PlayerDeath();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>() && damageDelay <= 0)
        {
            damageDelay = 100;
            health -= 49;
        }
        else if (other_obj.GetComponent<GuyBullet>() && damageDelay <= 0)
        {
            damageDelay = 100;
            health -= 90;
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
            health += Time.deltaTime * currentHealthRegen;
    }
    private void SetHealth()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void PlayerDeath()
    {
        
        if (health <= 0)
        {
            DogeScript.DogeIsDead();
        }
    }

}
