using UnityEngine;
using System.Collections;

public class GuyBullet : MonoBehaviour {

    public static float bulletSpeed = 150;

    private Rigidbody2D rigid;



    // Use this for initialization
    void Start () {
	
	}
	
    public void Initialize()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Platform>())
        {
            Destroy(gameObject);
        }
    }

    public void setSpeed(float speed)
    {
        rigid.velocity = new Vector2(speed, 0);
    }
}
