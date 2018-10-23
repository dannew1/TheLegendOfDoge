using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour {

    private Doge dogeScript;
    private Shooting shootingScript;

    private Fireball fireballPrefab;
    private Vector2 fireballReturn;
    private Fireball activeFireball = null;

    private ThunderShield thundershieldPrefab;
    private Vector2 thundershieldReturn;
    private ThunderShield activeThundershield = null;


    private Vector2 zero = new Vector2(0, 0);

    // Use this for initialization
    void Start()
    {
        dogeScript = GetComponent<Doge>();
        shootingScript = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        fireballPrefab = dogeScript.activeFireball;
        thundershieldPrefab = dogeScript.activeThundershield;
    }

    public Vector2 ShootFireball(float currentMana)
    {
        if (fireballPrefab != null)
        {
            if (activeFireball == null)
            {
                Fireball clone = (Fireball)Instantiate(fireballPrefab, transform.position, transform.rotation);
                clone.Initialize(gameObject);

                activeFireball = clone;

                if (clone.manaUsage > currentMana)
                {
                    Destroy(clone.gameObject);
                    shootingScript.NotEnoughForFireball();
                    return zero;
                }
            }
            else if (activeFireball.manaUsage > currentMana)
            {
                KillFireball();
                shootingScript.NotEnoughForFireball();
                return zero;
            }

            Vector2 temporaryReturn = new Vector2(activeFireball.manaUsage, activeFireball.reloadTime);
            if (activeFireball.reloadTime > 0)
            {
                shootingScript.NotEnoughForFireball();
                activeFireball = null;
            }
            return temporaryReturn;
        }
        return zero;
    }

    public Vector2 ShootThundershield(float currentMana)
    {
        if (thundershieldPrefab != null)
        {
            if (activeThundershield == null)
            {
                ThunderShield clone = (ThunderShield)Instantiate(thundershieldPrefab, transform.position, transform.rotation);
                clone.Initialize(gameObject);

                activeThundershield = clone;

                if (clone.manaUsage > currentMana)
                {
                    Destroy(clone.gameObject);
                    shootingScript.NotEnoughForThundershield();
                    return zero;
                }
            }
            else if (activeThundershield.manaUsage > currentMana)
            {

                KillThundershield();
                shootingScript.NotEnoughForThundershield();
                return zero;
            }

            Vector2 temporaryReturn = new Vector2(activeThundershield.manaUsage, activeThundershield.reloadTime); ;
            if (activeThundershield.reloadTime > 0)
            {
                shootingScript.NotEnoughForThundershield();
            }
            return temporaryReturn;
        }
        return zero;
    }

    public void KillFireball()
    {
        if (fireballPrefab != null)
        {
            activeFireball.KillThis();
            activeFireball = null;
        }
    }

    public void KillThundershield()
    {
        if (thundershieldPrefab != null)
        {
            activeThundershield.KillThis();
            activeThundershield = null;
        }
    }
}