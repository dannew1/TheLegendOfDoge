using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    public Fireball fireballPrefab;

//    public float speed = 1;
//    public float topSpeed = 100;
//    public float jumpHeight = 100;


    //private float time_in_air = 0;
//    private float time_in_air = 0;
    private Rigidbody2D rigid;
    private bool dogeIsGrounded = false;
    private Vector3 dogeScale;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        
}
    }

    // Update is called once per frame
    void Update()
    {
        
        move_doge();
        turnAroundDoge();
        shootFireBall();
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
    private void turnAroundDoge()
    {

        if(rigid.velocity.x < 0)
        {
            transform.localScale = new Vector3(20, 20, 1);
        }
        else if (rigid.velocity.x > 0)
        {
            transform.localScale = new Vector3(-20, 20, 1);
        }
    }

    private void shootFireBall()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Fireball clone = (Fireball)Instantiate(fireballPrefab, transform.position, transform.rotation);
        }
    }
}
