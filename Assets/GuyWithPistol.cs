using UnityEngine;
using System.Collections;

public class GuyWithPistol : MonoBehaviour {

    public float turnTime;

    private Rigidbody2D rigid;
    private Vector3 initialScale;

    private bool guyLookingRight;
    private float timeCounter;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
        guyLookingRight = false;
        timeCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        whenToTurnGuy();
        Debug.Log(timeCounter);
    }

    private void whenToTurnGuy()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 5)
        {
            turnAroundGuy();
            timeCounter = 0;
        }
    }


    private void turnAroundGuy()
    {
        if (guyLookingRight == true)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
            guyLookingRight = false;
        }
        else if (guyLookingRight == false)
        {
            transform.localScale = new Vector3(initialScale.x * -1, initialScale.y, initialScale.z);
            guyLookingRight = true;
        }
    }
}
