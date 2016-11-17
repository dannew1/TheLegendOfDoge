using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rigid;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        turnAroundEnemy();
    }

    private void turnAroundEnemy()
    {

        if (rigid.velocity.x < 0)
        {
            transform.localScale = new Vector3(20, 20, 1);
        }
        else if (rigid.velocity.x > 0)
        {
            transform.localScale = new Vector3(-20, 20, 1);
        }
    }
}
