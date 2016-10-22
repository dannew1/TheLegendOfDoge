using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rigid;
    private float time;
    private float goToPosition;
    private float numberOfResets;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        time = 7;
        numberOfResets = 1;
        //transform.position = new Vector3(0, 0, 0);
        goToPosition = Random.Range(100, 500);
        Debug.Log(goToPosition);
    }
	
	// Update is called once per frame
	void Update () {
        enemy_movement();
        
    }

    public void enemy_movement()
    {
        time -= Time.deltaTime;
        if (transform.position.x <= goToPosition)
        {
            rigid.velocity += new Vector2((float)0.3, 0);
        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }

        if (transform.position.x >= goToPosition)
        {
            if (time <= 0 && numberOfResets >= 1)
            {
                time = 10;
                numberOfResets -= 1;
            }
            if (time <= 0)
            {
                goToPosition = Random.Range(500, 900);
                Debug.Log(goToPosition);
            }
        }
    }
}
