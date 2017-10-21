using UnityEngine;
using System.Collections;

public class MoveDoge : MonoBehaviour {

    private Rigidbody2D rigid;
    private Vector3 initialScale;

    public float speed = 16;
    public float topSpeed = 250;
    public float jumpHeight = 350;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    private bool dogeIsGrounded = false;
    private float timeInAir;
    private bool lockSpeedR = false;
    private bool lockSpeedL = false;

    public bool isDogeLookingRight = true;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        Move_doge();
        TurnAroundDoge();
        SetDogeLookingRight();
        IsDogeGrounded();
        TimeInAir();
    }

    private void Move_doge()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && rigid.velocity.x > 0)
        {
            rigid.velocity += new Vector2(-speed * 3, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && nonTopSpeed())
        {
            rigid.velocity += new Vector2(-speed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) && rigid.velocity.x < 0)
        {
            rigid.velocity += new Vector2(speed * 3, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && nonTopSpeed())
        {
            rigid.velocity += new Vector2(speed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) == false)
        {
            lockSpeedR = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && nonTopSpeed() == false)
        {
            lockSpeedR = true;
        }
        if (lockSpeedR == true)
        {
            rigid.velocity = new Vector2(topSpeed, rigid.velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == false)
        {
            lockSpeedL = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && nonTopSpeed() == false)
        {
            lockSpeedL = true;
        }
        if (lockSpeedL == true)
        {
            rigid.velocity = new Vector2(-topSpeed, rigid.velocity.y);
        }

        if (Input.GetKey(KeyCode.UpArrow) && NoYMovement())
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rigid.velocity += new Vector2(0, jumpHeight / (300 * timeInAir));
        }
    }

    private void TimeInAir()
    {
        if (NoYMovement() == true)
        {
            timeInAir = 0;
        }

        else if (NoYMovement() == false)
        {
            timeInAir += Time.deltaTime;
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

    private void SetDogeLookingRight()
    {
        if (rigid.velocity.x < 0)
        {
            isDogeLookingRight = false;
        }
        else if (rigid.velocity.x > 0)
        {
            isDogeLookingRight = true;
        }
    }

    private void TurnAroundDoge()
    {
        if (isDogeLookingRight == false)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        else if (isDogeLookingRight == true)
        {
            transform.localScale = new Vector3(initialScale.x * -1, initialScale.y, initialScale.z);
        }
    }
}
