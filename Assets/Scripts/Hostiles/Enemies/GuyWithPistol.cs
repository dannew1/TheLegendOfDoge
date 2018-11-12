using UnityEngine;
using System.Collections;

public class GuyWithPistol : Enemy {

    public GuyBullet bulletPrefab;

    public static float maxHealth = 30;
    public static float turnTime = 1.5f;
    public static float turnOffset = 0.75f;
    public static float fireDelay = 0.5f;
    public static Vector2 viewRange = new Vector2(93, 8);

    private float turnCounter;
    private float fireCounter;

    // Use this for initialization
    void Start () {
        Initialize();

        SetEnemyHealth(maxHealth);
        updateLookingRight = false;
        enemyBodyDamage = 40;

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
        turnCounter += Random.Range(1-turnOffset, 1+ turnOffset) * Time.deltaTime;
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
        if (enemyCurrentBox == player.currentBox)
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
