using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheSign : MonoBehaviour {

    public Text storyText;

    private bool overlappingDoge = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        activateSign();
    }

    private void activateSign()
    {
        if (overlappingDoge == true && Input.GetKeyDown(KeyCode.X))
        {
            storyText.text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        }
        else if(overlappingDoge == false && Input.GetKeyDown(KeyCode.X))
        {
            storyText.text = "";
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
