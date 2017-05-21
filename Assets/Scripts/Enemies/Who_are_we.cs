using UnityEngine;
using System.Collections;

public class Who_are_we : MonoBehaviour {

    public float range = 300;
    public float speed = 0.7F;
    public float baseWaitTime = 2.5F;

	private Rigidbody2D rigid;
    private float waitTime;
    private float goToPosition;
    private float maxRange;
    private float minRange;

    

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        waitTime = baseWaitTime;
        maxRange = transform.position.x + range;
        minRange = transform.position.x - range;
        goToPosition = Random.Range(minRange, maxRange);
    }
	
	// Update is called once per frame
	void Update () {
        enemy_movement();
        
    }

    public void enemy_movement()
    {

        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            if (transform.position.x + 10 >= goToPosition && transform.position.x - 10 <= goToPosition)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                goToPosition = Random.Range(minRange, maxRange);
                waitTime = baseWaitTime;
            }
            else if (goToPosition >= transform.position.x)
            {
                rigid.velocity += new Vector2(speed, 0);
            }

            else if (goToPosition <= transform.position.x)
            {
                rigid.velocity += new Vector2(-speed, 0);
            }
        }
    }
}
