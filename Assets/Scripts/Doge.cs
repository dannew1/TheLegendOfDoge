using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    private Shooting shootingScript;
    private DogeHealth healthScript;

    public float healthValue; 
    public float manaValue;
    
    public bool dogeLookingRight = true;
    public float speed = 3;
    public float topSpeed = 100;
    public float jumpHeight = 100;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    public GameObject levelManager;
    private ChangeScene changeSceneScript;

    private Rigidbody2D rigid;
    private bool dogeIsGrounded = false;
    private Vector3 initialScale;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
        changeSceneScript = levelManager.GetComponent<ChangeScene>();
        shootingScript = GetComponent<Shooting>();
        healthScript = GetComponent<DogeHealth>();
    }

// Update is called once per frame
    void Update()
    {
        Move_doge();
        TurnAroundDoge();
        SetDogeLookingRight();
        IsDogeGrounded();


        SetHealthValue();
        SetManaValue();
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

    public bool nonTopSpeed()
    {
        return rigid.velocity.x <= topSpeed && rigid.velocity.x >= -topSpeed;
    }

    private void IsDogeGrounded()
    {
        dogeIsGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer);
    }
    
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

    private void SetHealthValue()
    {
        healthValue = healthScript.health;
    }

    private void SetManaValue()
    {
        manaValue = shootingScript.mana;
    }
}