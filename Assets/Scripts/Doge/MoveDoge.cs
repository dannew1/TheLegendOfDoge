using UnityEngine;
using System.Collections;
using System;

public class MoveDoge : MonoBehaviour {

    private Doge dogeScript;

    private Rigidbody2D rigid;
    private Vector3 initialScale;

    private float acceleration = 16;
    private float topSpeed = 250;
    private float jumpHeight = 350;
    private float friction = 10;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    private float timeInAir;
    private bool lockSpeedR = false;
    private bool lockSpeedL = false;

    private bool isDogeLookingRight = true;

    // Use this for initialization
    void Start () {
        dogeScript = GetComponent<Doge>();

        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;

        acceleration = dogeScript.baseAcceleration;
        topSpeed = dogeScript.baseTopSpeed;
        jumpHeight = dogeScript.baseJumpHeight;
    }
	
	// Update is called once per frame
	void Update () {
        Move_doge();
        TurnAroundDoge();
        SetDogeLookingRight();
        TimeInAir();
        Friction();
    }

    private void Move_doge()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rigid.velocity.x > 0)
            {
                rigid.velocity += new Vector2(-CurretAcceleration() * 3, 0);
            }
            else if (NonTopSpeed())
            {
                rigid.velocity += new Vector2(-CurretAcceleration(), 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rigid.velocity.x < 0)
            {
                rigid.velocity += new Vector2(CurretAcceleration() * 3, 0);
            }
            else if (NonTopSpeed())
            {
                rigid.velocity += new Vector2(CurretAcceleration(), 0);
            }
        }

        if (!Input.GetKey(KeyCode.RightArrow))
        {
            lockSpeedR = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !NonTopSpeed())
        {
            lockSpeedR = true;
        }
        if (lockSpeedR == true)
        {
            rigid.velocity = new Vector2(topSpeed, rigid.velocity.y);
        }

        if (!Input.GetKey(KeyCode.LeftArrow))
        {
            lockSpeedL = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !NonTopSpeed())
        {
            lockSpeedL = true;
        }
        if (lockSpeedL == true)
        {
            rigid.velocity = new Vector2(-topSpeed, rigid.velocity.y);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (NoYMovement())
            {
                timeInAir = 0;
                rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
            }
            else
            {
                rigid.velocity += new Vector2(0, jumpHeight*2 / (600 * timeInAir));
            }
        }
    }

    private void Friction()
    {
        if(DogeNotMoving() && DogeIsGrounded())
        {
            if (rigid.velocity.x > -10 && rigid.velocity.x < 10)
            {
                rigid.velocity += new Vector2(rigid.velocity.x * -0.20f, 0);
            }
            else
            {
                rigid.velocity += new Vector2(rigid.velocity.x * -0.06f, 0);
            }
        }
    }

    private float CurretAcceleration()
    {
        if(NoYMovement())
        {
            return acceleration;
        }
        else
        {
            return acceleration / 2;
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

    private bool DogeNotMoving()
    {
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool NonTopSpeed()
    {
        return rigid.velocity.x <= topSpeed && rigid.velocity.x >= -topSpeed;
    }

    private bool NoYMovement()
    {
        return rigid.velocity.y <= 10 && rigid.velocity.y >= -10 && DogeIsGrounded();
    }

    private bool DogeIsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer);
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

    public bool ReturnMoveValues(int stat)
    {
        if (stat == 1)
        {
            return isDogeLookingRight;
        }

        else
        {
            return false;
        }

    }
}
