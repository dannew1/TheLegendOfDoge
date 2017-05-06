﻿using UnityEngine;
using System.Collections;

public class DogeHealth : MonoBehaviour
{
    private Doge dogeScript;
    private ChangeScene changeSceneScript;

    public float maxHealth = 100;
    public float healthRegen = 3;
    public float health;

    private float damageDelay = 3;

    // Use this for initialization
    void Start()
    {
        dogeScript = GetComponent<Doge>();
        health = maxHealth;
        changeSceneScript = dogeScript.levelManager.GetComponent<ChangeScene>();
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
    }

    private void DamageDelayCountdown()
    {
        if (damageDelay >= -20)
        {
            damageDelay -= Time.deltaTime * 100;
        }
    }
    private void HealthRegen()
    {
        if (health < maxHealth && damageDelay <= 0)
            health += Time.deltaTime * healthRegen;
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
            changeSceneScript.GameOver();
        }
    }

}
