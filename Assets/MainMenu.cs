﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text tutorialText;
    public GameObject loadingBlock;
    private float timer;
    private bool slowTimer1 = false;
    private bool slowTimer2 = false;
    private bool slowTimer3 = false;
    private float tutorialStep;

	// Use this for initialization
	void Start () {
        

        ActivateTutorialStep1();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTutorial();
	}

    public void StartTutorial()
    {
        ActivateTutorialStep1();
    }
    public void LoadingBlockCollider()
    {
        if(tutorialStep == 1)
        {
            ActivateTutorialStep2();
        }
        else if (tutorialStep == 2)
        {
            ActivateTutorialStep3();
        }
    }

    private void UpdateTutorial()
    {
        if (tutorialStep == 1)
        {
            TutorialStep1();
        }
        else if (tutorialStep == 2)
        {
            TutorialStep2();
        }
        else if (tutorialStep == 3)
        {
            TutorialStep3();
        }
    }

    private void ActivateTutorialStep1()
    {
        timer = 0;
        tutorialText.text = "Walk here";
        tutorialStep = 1;
    }
    private void ActivateTutorialStep2()
    {
        timer = 0;
        tutorialText.text = "Now here";
        tutorialStep = 2;
    }
    private void ActivateTutorialStep3()
    {
        timer = 0;
        tutorialText.text = "Lets go ahead and kill this enemy";
        tutorialStep = 3;
    }

    private void TutorialStep1()
    {
        timer += Time.deltaTime * 10;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            timer = 0;
        }
        if(timer >= 100)
        {
            tutorialText.text = "You are supposed to use the arrow keys";
            slowTimer1 = true;
        }      
    }

    private void TutorialStep2()
    {
        timer += Time.deltaTime * 10;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            timer = 0;
        }
        if (timer >= 150 && slowTimer1 == false)
        {
            tutorialText.text = "You are supposed to jump using the arrow keys";
            slowTimer2 = true;
        }
        else if (timer >= 150 && slowTimer1 == true)
        {
            tutorialText.text = "Arrow keys... Same as before";
            slowTimer2 = true;
        }
    }
    private void TutorialStep3()
    {
        timer += Time.deltaTime * 10;
        if (Input.GetKey(KeyCode.C))
        {
            timer = 0;
        }
        if (timer >= 100)
        {
            tutorialText.text = "Guess I should say you shoot with C";
            slowTimer3 = true;
        }
    }

    //notes
    //block x-46 y-58 
    //arrow1 x171 y-64 r-1.5 
    //arrow2 x-170 y30 r-33
    //arrow3 x-49 y63 r271 
    //arrow4 x79 y14 r210 
    //arrow5 x79 y-78 r178
    //
}
