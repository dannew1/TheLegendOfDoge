using UnityEngine;
using System.Collections;

public class LoadingObject : MonoBehaviour {

    public GameObject loadingObject;
    public MainMenu tutorialScript;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        CheckObject();
    }

    private void CheckObject()
    {
        if (loadingObject == null)
        {
            tutorialScript.EnemyNextStep();
        }
    }
}
