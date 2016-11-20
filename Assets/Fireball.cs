using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    private Rigidbody2D rigid;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(100, 0);
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
}
