using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

public class Enemy : MonoBehaviour {

    public float enemyBodyDamage;

    private Image mask;
    private Vector3 barScale;

    private Image healthBar;
    private float enemyHealth;
    private float enemyMaxHealth;
    private float healthBarTimer = 0;

    private Image damageBar;
    private float damageDelay;
    private float beforeHitHealth;
    private float lateDamageAmount;
    private float damageBarTimer = 0;

    private float baseDamageBarTimer = 1;
    private float baseDamageDelay = 1;
    private float baseHealthBarTimer = 6;

    protected bool enemyLookingRight = false;
    protected bool updateLookingRight = true;
    protected bool kamekazeUnit = false;
    protected Rigidbody2D rigid;
    protected Vector3 initialScale;

    private List<GameObject> activeWeapons = new List<GameObject>();
    private List<GameObject> deadWeapons = new List<GameObject>();

    protected void Initialize()
    {
        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;

        mask = gameObject.transform.GetChild(0).GetComponent<Image>();
        healthBar = mask.gameObject.transform.GetChild(1).GetComponent<Image>();
        damageBar = mask.gameObject.transform.GetChild(0).GetComponent<Image>();
        barScale = mask.transform.localScale;
    }
    // Use this for initialization
    void Start () {
        
    }

    protected void CustomUpdate()
    {
        KillEnemy();
        HealthBar();
        DamageBar();

        SetLookingDirection();
        turnAroundEnemy();

        ActiveWeaponDamage();
        DeadWeaponList();
    }

    protected void SetEnemyHealth(float value)
    {
        enemyMaxHealth = value;
        enemyHealth = enemyMaxHealth;
        beforeHitHealth = enemyMaxHealth;
    }

    private void KillEnemy()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void HealthBar()
    {
        healthBar.fillAmount = enemyHealth / enemyMaxHealth;

        if (healthBarTimer > 0)
        {
            healthBarTimer -= Time.deltaTime;
        }
        
        if(healthBarTimer <= 0)
        {
            mask.color = new Color(0.8f, 0.8f, 0.8f, 0);
            healthBar.color = new Color(1, 0, 0, 0);
            damageBar.color = new Color(1, 0.55f, 0.25f, 0);
        }
        else if(healthBarTimer > 0 && healthBarTimer < 1)
        {
            mask.color = new Color(0.8f, 0.8f, 0.8f, healthBarTimer);
            healthBar.color = new Color(1, 0, 0, healthBarTimer);
            damageBar.color = new Color(1, 0.55f, 0.25f, healthBarTimer);
        }
        else
        {
            mask.color = new Color(0.8f, 0.8f, 0.8f, 1);
            healthBar.color = new Color(1, 0, 0, 1);
            damageBar.color = new Color(1, 0.55f, 0.25f, 1);
        }
    }

    private void DamageBar()
    {
        if (damageBarTimer <= 0)
        {
            if(beforeHitHealth > enemyHealth)
            {
                beforeHitHealth -= lateDamageAmount * Time.deltaTime;
            }
            else
            {
                beforeHitHealth = enemyHealth;
            }
        }
        else
        {
            damageBarTimer -= Time.deltaTime;
            lateDamageAmount = beforeHitHealth - enemyHealth;
        }

        damageBar.fillAmount = beforeHitHealth / enemyMaxHealth;
    }

    private void SetLookingDirection()
    {
        if (updateLookingRight)
        {
            if (rigid.velocity.x < 0)
            {
                enemyLookingRight = false;
            }
            else if (rigid.velocity.x > 0)
            {
                enemyLookingRight = true;
            }
        }
    }

    private void turnAroundEnemy()
    {
        if (enemyLookingRight == false)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
            mask.transform.localScale = barScale;
        }
        else if (enemyLookingRight == true)
        {
            transform.localScale = new Vector3(initialScale.x * -1, initialScale.y, initialScale.z);
            mask.transform.localScale = new Vector3(barScale.x * -1, barScale.y, barScale.z);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;
    
        if (other_obj.GetComponent<Weapon>())
        {
            TakeDamage(other_obj);
            activeWeapons.Add(other_obj);
        }
        else if (other_obj.GetComponent<Doge>())
        {
            HitDoge();
        }
    }

    private void HitDoge()
    {
        if(kamekazeUnit)
        {
            Destroy(gameObject);
        }
    }

    private void ActiveWeaponDamage()
    {
        if (damageDelay > 0)
        {
            damageDelay -= Time.deltaTime * 60;
            // -60/s
        }

        if (damageDelay <= 0 && activeWeapons.Any())
        {
            foreach (GameObject weapon in activeWeapons)
            {
                if (weapon == null)
                {
                    deadWeapons.Add(weapon);
                }
                else
                {
                    TakeDamage(weapon);
                }
            }
            damageDelay = baseDamageDelay;
        }
    }

    private void TakeDamage(GameObject weaponObj)
    {
            damageBarTimer = baseDamageBarTimer;
            enemyHealth -= weaponObj.GetComponent<Weapon>().damage;
            healthBarTimer = baseHealthBarTimer;
    }

    private void DeadWeaponList()
    {
        if (deadWeapons.Any())
        {
            foreach (GameObject deadWeapon in deadWeapons)
            {
                activeWeapons.Remove(deadWeapon);
            }
            deadWeapons.Clear();
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Weapon>())
        {
            activeWeapons.Remove(other_obj);
        }
    }
}
