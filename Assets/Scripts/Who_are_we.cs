using UnityEngine;
using System.Collections;

public class Who_are_we : MonoBehaviour {

	private Rigidbody2D rigid;
    private float time;
    private float goToPosition;
    public float speed = 0.7F;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        time = 2;
        goToPosition = Random.Range(100, 900);
        Debug.Log(goToPosition);
    }
	
	// Update is called once per frame
	void Update () {
        enemy_movement();
        
    }

    public void enemy_movement()
    {

        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (transform.position.x + 10 >= goToPosition && transform.position.x - 10 <= goToPosition)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                goToPosition = Random.Range(100, 900);
                time = Random.Range((float)0.3, 4);
                Debug.Log(goToPosition);
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
