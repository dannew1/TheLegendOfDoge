using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    public Fireball fireballPrefab;

    public float maxHealth = 100;
    public float healthValue;
    public float healthRegen = 3;

    public float maxMana = 100;
    public float manaValue;
    public float manaRegen = 4;
    public float shootingDelay = 2;
    public float manaUsage = 20;

    public float speed = 3;
    public float topSpeed = 100;
    public float jumpHeight = 100;
    public Transform GroundCheck1;
    public LayerMask groundLayer;
        

    private Rigidbody2D rigid;
    private bool dogeIsGrounded = false;
    private Vector3 initialScale;

    private float reloadTime = 0;
    private float shootingDirection = 2;
    private bool dogeLookingRight = true;
    private float fireballSpeed;
    private float mana;

    private float damageDelay;
    private float health;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;

        health = maxHealth;
        mana = maxMana;
        shootingDelay = Fireball.reloadTime;
        manaUsage = Fireball.manaUsage;
        fireballSpeed = Fireball.fireballSpeed;
    }

// Update is called once per frame
void Update()
    {
        Move_doge();
        TurnAroundDoge();
        SetDogeLookingRight();
        IsDogeGrounded();

        ShootFireBall();
        SetShootingDirection();
        
        DamageDelayCountdown();
        HealthRegen();
        SetHealthValue();
        PlayerDeath();

        ManaRegen();
        SetManahValue();
    }

    public void Move_doge()
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

        if (Input.GetKey(KeyCode.UpArrow) && NoYMovement())
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.velocity += new Vector2(0, -jumpHeight/100);
        }
    }

    private bool NoYMovement()
    {
        return rigid.velocity.y <= 10 && rigid.velocity.y >= -10 && dogeIsGrounded;
    }

    private bool nonTopSpeed()
    {
        return rigid.velocity.x <= topSpeed && rigid.velocity.x >= -topSpeed;
    }

    private void IsDogeGrounded()
    {
        dogeIsGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer);
    }
    //void OnCollisionStay2D(Collision2D col)
    //{
    //    dogeIsGrounded = true;
    //}
    //
    //void OnCollisionExit2D(Collision2D col)
    //{
    //    dogeIsGrounded = false;
    //}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>() && damageDelay <= 0)
        {
            damageDelay = 100;
            health -= 49;
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
    private void SetDogeLookingRight()
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

    private void TurnAroundDoge()
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

    private void SetShootingDelay ()
        {
            reloadTime = shootingDelay;
        }

    private void ShootFireBall()
    {
        reloadTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.C) && reloadTime <= 0 && mana > manaUsage)
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
            SetShootingDelay();
            mana -= manaUsage;
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
    private void DamageDelayCountdown()
    {
        if(damageDelay >= -20)
        {
            damageDelay -= Time.deltaTime * 100;
        }
    }
    private void HealthRegen()
    {
        if (health < maxHealth && damageDelay <= 0)
        health += Time.deltaTime * healthRegen;
    }
    private void ManaRegen()
    {
        if (mana < maxMana && reloadTime <= 0)
            mana += Time.deltaTime * manaRegen;
    }
    private void SetHealthValue()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthValue = health;
    }
    private void PlayerDeath()
    {
        if (health <= 0)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene("EndScreen");
        }
    }
    private void SetManahValue()
    {
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        manaValue = mana;
    }
}