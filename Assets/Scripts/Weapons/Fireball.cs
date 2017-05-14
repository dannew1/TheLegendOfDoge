using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public Rigidbody2D rigid;

    public static float reloadTime = 2;
    public static float manaUsage = 20;
    public static float fireballSpeed = 150;

    // Use this for initialization

    void Start () {
        
    }

	public void Initialize()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

	void Update () {
	    
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            Destroy(gameObject);
        }
    }

    public void setSpeed(float speed)
    {
        rigid.velocity = new Vector2(speed, 0);
    }
}
