using UnityEngine;
using System.Collections;

public class GuyWithPistol : Enemy {

    public GuyBullet bulletPrefab;

    public float health = 30;

    public float turnTime = 4;
    public float fireDelay = 0.5F;
    public Vector2 viewRange = new Vector2(500, 100);
    public GameObject player;

    private float turnCounter;
    private float fireCounter;

    // Use this for initialization
    void Start () {
        Initialize();

        SetEnemyHealth(health);
        updateLookingRight = false;
        enemyBodyDamage = 1000;

        turnCounter = 0;
        fireCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        CustomUpdate();
        FireAtDoge();
        WhenToTurnGuy();
    }

    private void WhenToTurnGuy()
    {
        turnCounter += Time.deltaTime;
        if (turnCounter >= turnTime)
        {
            turnAroundGuy();
            turnCounter = 0;
        }
    }

    private void turnAroundGuy()
    {
        if (enemyLookingRight == true)
        {
            enemyLookingRight = false;
        }
        else if (enemyLookingRight == false)
        {
            enemyLookingRight = true;
        }
    }

    private bool DogeInViewRange()
    {
        Vector2 distanceToDoge = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);

        if (IsValueBetween(distanceToDoge.y, -viewRange.y, viewRange.y))
        {
            if (IsValueBetween(distanceToDoge.x, 0, viewRange.x) && enemyLookingRight == false)
            {
                return true;
            }
            else if (IsValueBetween(distanceToDoge.x, -viewRange.x, 0) && enemyLookingRight == true)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsValueBetween(float value, float low, float high)
    {
        if (value > low && value < high)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FireAtDoge()
    {
        if(DogeInViewRange())
        {
            turnCounter = 0;
            fireCounter += Time.deltaTime;
            if (fireCounter >= fireDelay)
            {
                fireCounter = 0;
                ShootBullet();
            }
        }
        else
        {
            fireCounter = 0;
        }
    }

    private void ShootBullet()
    {
            GuyBullet clone = (GuyBullet)Instantiate(bulletPrefab, transform.position, transform.rotation);
            clone.Initialize();
            if (enemyLookingRight == false)
            {
                clone.setSpeed(-GuyBullet.bulletSpeed);
            }
            else if (enemyLookingRight == true)
            {
                clone.setSpeed(GuyBullet.bulletSpeed);
            }
    }
}
