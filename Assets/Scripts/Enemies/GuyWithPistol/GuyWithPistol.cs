using UnityEngine;
using System.Collections;

public class GuyWithPistol : Enemy {

    //private Enemy enemyScript;
    public GuyBullet bulletPrefab;

    public float health = 30;

    public float turnTime = 4;
    public float fireDelay = 0.5F;
    public Vector2 viewRange = new Vector2(500, 100);
    public GameObject player;

    //private Rigidbody2D rigid;
    //private Vector3 initialScale;

    //private bool guyLookingRight;
    private float turnCounter;
    private float fireCounter;

    // Use this for initialization
    void Start () {
        Initialize();
        //enemyScript = GetComponent<Enemy>();
        //rigid = GetComponent<Rigidbody2D>();
        //initialScale = transform.localScale;

        SetEnemyHealth(health);
        updateLookingRight = false;

        //guyLookingRight = false;
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
            //transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
            enemyLookingRight = false;
        }
        else if (enemyLookingRight == false)
        {
            //transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
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
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
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
