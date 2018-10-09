using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheSign : MonoBehaviour {

    private bool overlappingDoge = false;
    private StoryText storyScript;

	// Use this for initialization
	void Start () {
        storyScript = GetComponent<StoryText>();
	}
	
	// Update is called once per frame
	void Update () {
        activateSign();
    }

    private void activateSign()
    {
        if (storyScript.GetInStory() == true && Input.GetKeyDown(KeyCode.X))
        {
            storyScript.ContinueText();
        }
        else if (overlappingDoge == true && Input.GetKeyDown(KeyCode.X))
        {
            storyScript.StartText();
        }
        else if(Input.GetKeyDown(KeyCode.Z))
        {
            storyScript.ClearText();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Doge>())
        {
            overlappingDoge = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Doge>())
        {
            overlappingDoge = false;
        }
    }
}
