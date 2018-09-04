using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DogeHealth : MonoBehaviour
{
    private Doge dogeScript;

    private float maxHealth;
    private float healthRegen;
    private float health;

    private float baseDamageDelay = 1;

    private float damageDelay = 3;
    private bool unkillable = false;

    private List<GameObject> activeEnemyWeapon = new List<GameObject>();
    private List<GameObject> deadEnemyWeapon = new List<GameObject>();
    private List<GameObject> activeEnemy = new List<GameObject>();
    private List<GameObject> deadEnemy = new List<GameObject>();

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
        SetStats();

        ActiveEnemyDamage();
        DeadEnemyLists();

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

    //public void OnTriggerStay2D(Collider2D collider)
    //{
    //    GameObject other_obj = collider.gameObject;
    //    if (!unkillable)
    //    {
    //        if (other_obj.GetComponent<Enemy>() && damageDelay <= 0)
    //        {
    //            health -= 490;
    //            damageDelay = 100;
    //        }
    //        else if (other_obj.GetComponent<GuyBullet>() && damageDelay <= 0)
    //        {
    //            health -= 900;
    //            damageDelay = 100;
    //        }
    //    }
    //}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            TakeDamage(other_obj);
            activeEnemy.Add(other_obj);
        }
        else if (other_obj.GetComponent<EnemyWeapon>())
        {
            TakeDamage(other_obj);
            activeEnemyWeapon.Add(other_obj);
        }
    }

    private void ActiveEnemyDamage()
    {
        if (damageDelay > 0)
        {
            damageDelay -= Time.deltaTime * 60;
            // -60/s
        }

        if (damageDelay <= 0 && (activeEnemy.Any() || activeEnemyWeapon.Any()))
        {
            foreach (GameObject enemy in activeEnemy)
            {
                if (enemy == null)
                {
                    deadEnemy.Add(enemy);
                }
                else
                {
                    TakeDamage(enemy);
                }
            }
            foreach (GameObject enemyWeapon in activeEnemyWeapon)
            {
                if (enemyWeapon == null)
                {
                    deadEnemyWeapon.Add(enemyWeapon);
                }
                else
                {
                    TakeDamage(enemyWeapon);
                }
            }
            damageDelay = baseDamageDelay;
        }
    }

    private void TakeDamage(GameObject enemyObj)
    {
        if (!unkillable)
        {
            if (enemyObj.GetComponent<Enemy>())
            {
                health -= enemyObj.GetComponent<Enemy>().enemyBodyDamage;
            }
            else if (enemyObj.GetComponent<EnemyWeapon>())
            {
                health -= enemyObj.GetComponent<EnemyWeapon>().damage;
            }
        }
    }

    private void DeadEnemyLists()
    {
        if (deadEnemy.Any())
        {
            foreach (GameObject enemy in deadEnemy)
            {
                activeEnemy.Remove(enemy);
            }
            deadEnemy.Clear();
        }
        if (deadEnemyWeapon.Any())
        {
            foreach (GameObject weapon in deadEnemyWeapon)
            {
                activeEnemyWeapon.Remove(weapon);
            }
            deadEnemyWeapon.Clear();
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            activeEnemy.Remove(other_obj);
        }
        else if (other_obj.GetComponent<EnemyWeapon>())
        {
            activeEnemyWeapon.Remove(other_obj);
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
