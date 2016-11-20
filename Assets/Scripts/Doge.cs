using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    public Fireball fireballPrefab;

    private float time_in_air = 0;
    private Rigidbody2D rigid;
    private bool dogeIsGrounded = false;
    private Vector3 dogeScale;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        Fireball clone = (Fireball)Instantiate(fireballPrefab, transform.position, transform.rotation);
}

// Update is called once per frame
void Update()
    {
        
        move_doge();
        //gravity();
        turnAroundDoge();
    }

    public void move_doge()
    {
        
            if (Input.GetKey(KeyCode.LeftArrow) && rigid.velocity.x > 0)
        {
            rigid.velocity += new Vector2(-2, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && nonTopSpeed())
        {
            rigid.velocity += new Vector2(-1, 0);
        }

            if (Input.GetKey(KeyCode.RightArrow) && rigid.velocity.x < 0)
        {
            rigid.velocity += new Vector2(2, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && nonTopSpeed())
        {
            rigid.velocity += new Vector2(1, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) && noYMovement())
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 100);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.velocity += new Vector2(0, -1);
        }
    }

    private bool noYMovement()
    {
        return rigid.velocity.y <= 10 && rigid.velocity.y >= -10 && dogeIsGrounded;
    }

    private bool nonTopSpeed()
    {
        return rigid.velocity.x <= 100 && rigid.velocity.x >= -100;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        dogeIsGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        dogeIsGrounded = false;
    }

    public void gravity()
    {

        if (transform.position.y <= 100)
        {
            transform.position = new Vector3(transform.position.x, 100, 0);
            time_in_air = 0;
        }

        else
        {
            time_in_air += Time.deltaTime;
            transform.position -= new Vector3(0, 1, 0) * 3 * time_in_air;
        }

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

    public void stopOnPlatform(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Platform>())
        {
            transform.position = new Vector3(transform.position.x, 100, 0);
        }
    }
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
}