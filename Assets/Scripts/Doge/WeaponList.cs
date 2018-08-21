using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour {

    //private Doge dogeScript;

    private Shooting shootingScript;


    public Fireball fireballPrefab;
    private Vector2 fireballReturn;

    private Fireball activeFireball = null;
    private bool keepFireballActive = false;


    public ThunderShield thundershieldPrefab;
    private Vector2 thundershieldReturn;

    private ThunderShield activeThundershield = null;
    private bool keepThundershieldActive = false;


    private Vector2 zero = new Vector2(0, 0);

    // Use this for initialization
    void Start()
    {
        shootingScript = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 ShootFireball(float currentMana)
    {
        if (activeFireball == null)
        {
            Fireball clone = (Fireball)Instantiate(fireballPrefab, transform.position, transform.rotation);
            clone.Initialize(gameObject);

            activeFireball = clone;
            keepFireballActive = true;

            if(clone.manaUsage > currentMana)
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

    public Vector2 ShootThundershield(float currentMana)
    {
        if (activeThundershield == null)
        {
            ThunderShield clone = (ThunderShield)Instantiate(thundershieldPrefab, transform.position, transform.rotation);
            clone.Initialize(gameObject);

            activeThundershield = clone;
            keepThundershieldActive = true;

            if (clone.manaUsage > currentMana)
            {
                Destroy(clone.gameObject);
                shootingScript.NotEnoughForThundershield();
                return zero;
            }
        }
        else if(activeThundershield.manaUsage > currentMana)
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

    public void KillFireball()
    {
        activeFireball.KillThis();
        activeFireball = null;
    }

    public void KillThundershield()
    {
        activeThundershield.KillThis();
        activeThundershield = null;
    }
}