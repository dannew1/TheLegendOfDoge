using UnityEngine;
using System.Collections;

public class GuyWithPistol : MonoBehaviour {

    public GuyBullet bulletPrefab;

    public float turnTime = 4;
    public float fireDelay = 0.5F;
    public float viewRangeX = 500;
    public float viewRangeY = 100;
    public GameObject player;

    private Rigidbody2D rigid;
    private Vector3 initialScale;

    private bool guyLookingRight;
    private float timeCounter;
    private float fireCounter;
    private bool dogeInViewRange = false;
    private float distanceToDogeX;
    private float distanceToDogeY;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();

        initialScale = transform.localScale;
        guyLookingRight = false;
        timeCounter = 0;
        fireCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        checkForPlayer();
        FireAtDoge();
        whenToTurnGuy();
    }

    private void whenToTurnGuy()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= turnTime)
        {
            turnAroundGuy();
            timeCounter = 0;
        }
    }

    private void turnAroundGuy()
    {
        if (guyLookingRight == true)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
            guyLookingRight = false;
        }
        else if (guyLookingRight == false)
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
            guyLookingRight = true;
        }
    }

    private void checkForPlayer()
    {
        distanceToDogeX = transform.position.x - player.transform.position.x;
        distanceToDogeY = transform.position.y - player.transform.position.y;

        if (distanceToDogeY < viewRangeY && distanceToDogeY > -viewRangeY)
        {
            if (distanceToDogeX > 0 && distanceToDogeX < viewRangeX && guyLookingRight == false)
            {
                dogeInViewRange = true;
            }
            else if (distanceToDogeX < 0 && distanceToDogeX > -viewRangeX && guyLookingRight == true)
            {
                dogeInViewRange = true;
            }
            else
            {
                dogeInViewRange = false;
            }
        }
        else
        {
            dogeInViewRange = false;
        }
    }

    private void FireAtDoge()
    {
        if(dogeInViewRange == true)
        {
            timeCounter = 0;
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
            if (guyLookingRight == false)
            {
                clone.setSpeed(-GuyBullet.bulletSpeed);
            }
            else if (guyLookingRight == true)
            {
                clone.setSpeed(GuyBullet.bulletSpeed);
            }
        
    }
}
