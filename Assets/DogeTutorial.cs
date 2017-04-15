using UnityEngine;
using System.Collections;

public class DogeTutorial : MonoBehaviour {

    public MainMenu tutorialScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<LoadingBlock>())
        {
            tutorialScript.LoadingBlockCollider();   
        }
    }
}
