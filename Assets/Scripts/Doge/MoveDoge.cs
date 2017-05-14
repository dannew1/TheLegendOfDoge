using UnityEngine;
using System.Collections;

public class MoveDoge : MonoBehaviour {

    public bool isDogeLookingRight = true;
    public float speed = 4;
    public float topSpeed = 150;
    public float jumpHeight = 150;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    private Rigidbody2D rigid;
    private bool dogeIsGrounded = false;
    private Vector3 initialScale;

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
    }

    public void Move_doge()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && rigid.velocity.x > 0)
        {
            rigid.velocity += new Vector2(-speed * 2, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && nonTopSpeed())
        {
            rigid.velocity += new Vector2(-speed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) && rigid.velocity.x < 0)
        {
            rigid.velocity += new Vector2(speed * 2, 0);
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
            rigid.velocity += new Vector2(0, -jumpHeight / 100);
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
