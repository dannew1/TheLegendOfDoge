using UnityEngine;
using System.Collections;

public class TutorialEnemy : MonoBehaviour {

    public MainMenu tutorialScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnDisable ()
    {
        tutorialScript.EnemyNextStep();
    }

}
