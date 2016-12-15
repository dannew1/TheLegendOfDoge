using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    public Fireball fireballPrefab;

    public float speed = 1;
    public float topSpeed = 100;
    public float jumpHeight = 100;
    public float shootingDelay = 2;
    public float fireballSpeed = 150;

    //private float time_in_air = 0;
    private Rigidbody2D rigid;
    private bool dogeIsGrounded = false;
    private Vector3 dogeScale;
    private float reloadTime = 0;
    private float shootingDirection = 2;
    private bool dogeLookingRight = false;
    private Vector3 initialScale;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
    }

// Update is called once per frame
void Update()
    {
        move_doge();
        turnAroundDoge();
        shootFireBall();
        SetShootingDirection();
        setDogeLookingRight();
    }

    public void move_doge()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow) && rigid.velocity.x > 0)
        {
            rigid.velocity += new Vector2(-speed*2, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && nonTopSpeed())
        {
            rigid.velocity += new Vector2(-speed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) && rigid.velocity.x < 0)
        {
            rigid.velocity += new Vector2(speed*2, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && nonTopSpeed())
        {
            rigid.velocity += new Vector2(speed, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) && noYMovement())
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.velocity += new Vector2(0, -jumpHeight/100);
        }
    }

    private bool noYMovement()
    {
        return rigid.velocity.y <= 10 && rigid.velocity.y >= -10 && dogeIsGrounded;
    }

    private bool nonTopSpeed()
    {
        return rigid.velocity.x <= topSpeed && rigid.velocity.x >= -topSpeed;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        dogeIsGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        dogeIsGrounded = false;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            //Destroy(gameObject);
            SceneManager.LoadScene("EndScreen");
        }
    }

    //public void stopOnPlatform(Collider2D collider)
    //{
    //    GameObject other_obj = collider.gameObject;
    //
    //    if (other_obj.GetComponent<Platform>())
    //    {
    //        transform.position = new Vector3(transform.position.x, 100, 0);
    //    }
    //}
    private void setDogeLookingRight()
    {

        if(rigid.velocity.x < 0)
        {
            dogeLookingRight = false;
        }
        else if (rigid.velocity.x > 0)
        {
            dogeLookingRight = true;
        }
    }

    private void turnAroundDoge()
    {
        if(dogeLookingRight == false)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        else if (dogeLookingRight == true)
        {
            transform.localScale = new Vector3(initialScale.x*-1, initialScale.y, initialScale.z);
        }
    }

    private void setShootingDelay ()
        {
            reloadTime = shootingDelay;
        }

    private void shootFireBall()
    {
        reloadTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.C) && reloadTime <= 0)
        {
            Fireball clone = (Fireball)Instantiate(fireballPrefab, transform.position, transform.rotation);
            clone.Initialize();
            if (dogeLookingRight == false)
            {
                clone.setSpeed(-fireballSpeed);
            }
            else if (dogeLookingRight == true)
            {
                clone.setSpeed(fireballSpeed);
            }
            setShootingDelay();
        }
    }

    private void SetShootingDirection()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            shootingDirection = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            shootingDirection = 3;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && nonTopSpeed())
        {
            shootingDirection = 2;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && nonTopSpeed())
        {
            shootingDirection = 4;
        }
    }

    
}