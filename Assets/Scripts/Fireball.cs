using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public Rigidbody2D rigid;

    public float reloadTime = 1;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        //rigid.velocity = new Vector2(100, 0);
    }
	
	// Update is called once per frame
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

    public void FireFireball()
    {

    }
}
