using UnityEngine;
using System.Collections;

public class LoadingBlock : MonoBehaviour {

    public MainMenu tutorialScript;

    private bool b = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        b = false;
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        GameObject other_obj = collider.gameObject;

        
        if (other_obj.GetComponent<Doge>() && b == false)
        {
            tutorialScript.LoadingBlockCollider();
            b = true;
        }
    }
}
