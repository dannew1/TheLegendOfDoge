using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TheSign : MonoBehaviour {

    private bool overlappingDoge = false;
    private StoryText storyScript;
    private CameraController cameraScript;

    public Vector2 currentBox;
    public Vector2 boxSize = new Vector2(93, 53);

    // Use this for initialization
    void Start () {
        storyScript = GetComponent<StoryText>();
        cameraScript = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
        activateSign();
        currentBox = GetCurrentBox();
    }

    private Vector2 GetCurrentBox()
    {
        return new Vector2(
            (float)Math.Floor(
            (transform.position.x - boxSize.x / 2) / boxSize.x
            ) + 1,

            (float)Math.Floor(
            (transform.position.y - boxSize.y / 2) / boxSize.y
            ) + 1);
    }

    private void activateSign()
    {
        if (storyScript.GetInStory() == true)
        {
            if (!cameraScript.CallFunction(currentBox))
            {
                storyScript.InterruptText();
            }
        }

        if (storyScript.GetInStory() == true && Input.GetKeyDown(KeyCode.X))
        {
            storyScript.ContinueText();
            overlappingDoge = false;
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
