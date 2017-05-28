using UnityEngine;
using System.Collections;

public class GuyWithPistol : MonoBehaviour {

    public GuyBullet bulletPrefab;

    public float turnTime = 4;
    public GameObject player;

    private Rigidbody2D rigid;
    private Vector3 initialScale;

    private bool guyLookingRight;
    private float timeCounter;
    private float fireCounter;
    private bool dogeInViewRange = false;

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
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
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
        if(transform.position.x - player.transform.position.x > 0 && guyLookingRight == false)
        {
            dogeInViewRange = true;
        }
        else if (transform.position.x - player.transform.position.x < 0 && guyLookingRight == true)
        {
            dogeInViewRange = true;
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
            Debug.Log(fireCounter);
            timeCounter = 0;
            fireCounter += Time.deltaTime;
            if (fireCounter >= 3)
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
