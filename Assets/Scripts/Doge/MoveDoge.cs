using UnityEngine;
using System.Collections;
using System;

public class MoveDoge : MonoBehaviour {

    private Doge dogeScript;

    private Rigidbody2D rigid;
    private Vector3 initialScale;

    private float acceleration;
    private float accelerationMultiplier = 3;
    private float topSpeed;
    private float jumpHeight;
    private float timeInAirMultiplier = 250;
    private float friction = 30;
    private float frictionMultiplier = 0.5f;
    private float stopMargin = 5;
    private float groundRad = 0.3f;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    private float timeInAir;
    private bool lockSpeedR = false;
    private bool lockSpeedL = false;

    private bool isDogeLookingRight = false;

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
        if (!(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (rigid.velocity.x > 0)
                {
                    rigid.velocity += new Vector2(-CurretAcceleration() * accelerationMultiplier * Time.deltaTime, 0);
                }
                else if (NonTopSpeed())
                {
                    rigid.velocity += new Vector2(-CurretAcceleration() * Time.deltaTime, 0);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (rigid.velocity.x < 0)
                {
                    rigid.velocity += new Vector2(CurretAcceleration() * accelerationMultiplier * Time.deltaTime, 0);
                }
                else if (NonTopSpeed())
                {
                    rigid.velocity += new Vector2(CurretAcceleration() * Time.deltaTime, 0);
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
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (NoYMovement())
            {
                timeInAir = 0;
                rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
            }
            //else if (timeInAir > 0)
            //{
            //    rigid.velocity += new Vector2(0, jumpHeight /  timeInAir);
            //}
        }
    }

    private void Friction()
    {
        if(DogeNotMoving() && DogeIsGrounded())
        {
            if (rigid.velocity.x > -stopMargin && rigid.velocity.x < stopMargin)
            {
                rigid.velocity += new Vector2(rigid.velocity.x * -friction * Time.deltaTime, 0);
            }
            else
            {
                rigid.velocity += new Vector2(rigid.velocity.x * -(friction * frictionMultiplier) * Time.deltaTime, 0);
            }
        }
    }

    private float CurretAcceleration()
    {
        return acceleration;
        if (NoYMovement())
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
            timeInAir += timeInAirMultiplier * Time.deltaTime;
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
        return rigid.velocity.y <= stopMargin && rigid.velocity.y >= -stopMargin && DogeIsGrounded();
    }

    private bool DogeIsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck1.position, groundRad, groundLayer);
    }

    private void SetDogeLookingRight()
    {
        if (rigid.velocity.x < -stopMargin)
        {
            isDogeLookingRight = false;
        }
        else if (rigid.velocity.x > stopMargin)
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
