using UnityEngine;
using System.Collections;

public class Doge : MonoBehaviour
{
    private float time_in_air = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move_doge();
        gravity();
    }

    public void move_doge()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position -= new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position -= new Vector3(0, -4, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, 1, 0);
        }
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
            Destroy(gameObject);
        }
    }
}
