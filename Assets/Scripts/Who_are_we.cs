using UnityEngine;
using System.Collections;

public class Who_are_we : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("hej");
    }
}
