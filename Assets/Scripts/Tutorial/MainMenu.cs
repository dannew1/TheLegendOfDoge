using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text tutorialText;
    public GameObject Tutorial1Objects;
    public GameObject Tutorial2Objects;
    public GameObject Tutorial3Objects;
    public GameObject Tutorial4Objects;
    public GameObject player;
    private float timer;
    private bool slowTimer1 = false;
    private bool slowTimer2 = false;
    private bool slowTimer3 = false;
    private float tutorialStep;

	// Use this for initialization
	void Start () {
        player.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTutorial();
        SelectVisableObjects();
    }

    public void StartTutorial()
    {
        ActivateTutorialStep1();
    }
    public void LoadingBlockCollider()
    {
        if (tutorialStep == 1)
        {
            ActivateTutorialStep2();
        }
        else if (tutorialStep == 2)
        {
            ActivateTutorialStep3();
        }
    }
    public void EnemyNextStep()
    {
        if(tutorialStep == 3)
        {
            ActivateTutorialStep4();
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
        else if (tutorialStep == 4)
        {
            //TutorialStep4();
        }
    }

    private void ActivateTutorialStep1()
    {
        timer = 0;
        tutorialText.text = "Walk here";
        tutorialStep = 1;
        player.SetActive(true);
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
    private void ActivateTutorialStep4()
    {
        timer = 0;
        tutorialText.text = "You've done it!! The end is right here!";
        tutorialStep = 4;
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
    //private void TutorialStep4()
    //{
    //    timer += Time.deltaTime * 10;
    //    if ()
    //    {
    //        timer = 0;
    //    }
    //    if ()
    //    {
    //        
    //    }
    //}

    private void SelectVisableObjects()
    {
        if (tutorialStep == 1)
        {
            Tutorial1Objects.SetActive(true);
            Tutorial2Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial4Objects.SetActive(false);
        }
        else if (tutorialStep == 2)
        {
            Tutorial2Objects.SetActive(true);
            Tutorial1Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial4Objects.SetActive(false);
        }
        else if (tutorialStep == 3)
        {
            Tutorial3Objects.SetActive(true);
            Tutorial1Objects.SetActive(false);
            Tutorial2Objects.SetActive(false);
            Tutorial4Objects.SetActive(false);
        }
        else if (tutorialStep == 4)
        {
            Tutorial4Objects.SetActive(true);
            Tutorial1Objects.SetActive(false);
            Tutorial2Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
        }
        else
        {
            Tutorial1Objects.SetActive(false);
            Tutorial2Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial4Objects.SetActive(false);
        }
    }
}
