using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text tutorialText;
    public GameObject Tutorial1Objects;
    public GameObject Tutorial2Objects;
    public GameObject Tutorial3Objects;
    public GameObject Tutorial3Text;
    public GameObject Tutorial4Objects;
    public GameObject Tutorial5Objects;
    public GameObject Tutorial6Objects;
    public GameObject player;
    public GameObject stats;
    private float timer;
    private bool slowTimer1 = false;
    private float tutorialStep;

	// Use this for initialization
	void Start () {
        player.SetActive(false);
        stats.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTutorial();
        SelectVisableObjects();
        OtherNextStep();
    }

    public void StartTutorial()
    {
        ActivateTutorialStep1();
        stats.SetActive(false);
        player.transform.position = new Vector2(210, 60);
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
        else if (tutorialStep == 6)
        {
            tutorialStep = 0;
            player.SetActive(false);
            stats.SetActive(false);
            tutorialText.text = "";
        }
    }
    public void EnemyNextStep()
    {
        if(tutorialStep == 4)
        {
            ActivateTutorialStep5();
        }
        else if (tutorialStep == 5)
        {
            ActivateTutorialStep6();
        }
    }
    private void OtherNextStep()
    {
        if (tutorialStep == 3 && Input.GetKey(KeyCode.V))
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
            TutorialStep4();
        }
        else if (tutorialStep == 5)
        {
            TutorialStep5();
        }
        else if (tutorialStep == 6)
        {
            TutorialStep6();
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
        tutorialText.text = "Here are your current stats";
        tutorialStep = 3;
        stats.SetActive(true);
    }
    private void ActivateTutorialStep4()
    {
        timer = 0;
        tutorialText.text = "Lets go ahead and kill this enemy with the ThunderShield";
        tutorialStep = 4;
    }
    private void ActivateTutorialStep5()
    {
        timer = 0;
        tutorialText.text = "Oh no, a wall! Try using the fireball insted";
        tutorialStep = 5;
    }
    private void ActivateTutorialStep6()
    {
        timer = 0;
        tutorialText.text = "You've done it!! The end is right here!";
        tutorialStep = 6;
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
        }
        else if (timer >= 150 && slowTimer1 == true)
        {
            tutorialText.text = "Arrow keys... Same as before";
        }
    }

    private void TutorialStep3()
    {
        timer += Time.deltaTime * 10;
        if (timer >= 150)
        {
            tutorialText.text = "Got it? You can even change weapon with V";
        }
        if (timer >= 300)
        {
            tutorialText.text = "Ehm, press V";
        }
    }

    private void TutorialStep4()
    {
        timer += Time.deltaTime * 10;
        if (Input.GetKey(KeyCode.C))
        {
            timer = 0;
        }
        if (timer >= 80)
        {
            tutorialText.text = "Guess I should say you fire with C";
        }
    }

    private void TutorialStep5()
    {
        timer += Time.deltaTime * 10;
        if (Input.GetKey(KeyCode.C))
        {
            timer = 0;
        }
        if (timer >= 150)
        {
            tutorialText.text = "A recap, V to change weapon and C to fire.";
        }
    }

    private void TutorialStep6()
    {
        timer += Time.deltaTime * 10;
        if (timer >= 150)
        {
            tutorialText.text = "Walk into it please..";
        }
    }

    private void SelectVisableObjects()
    {
        if (tutorialStep == 1)
        {
            Tutorial1Objects.SetActive(true);
            Tutorial2Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial3Text.SetActive(false);
            Tutorial4Objects.SetActive(false);
            Tutorial5Objects.SetActive(false);
            Tutorial6Objects.SetActive(false);
        }
        else if (tutorialStep == 2)
        {
            Tutorial2Objects.SetActive(true);
            Tutorial1Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial3Text.SetActive(false);
            Tutorial4Objects.SetActive(false);
            Tutorial5Objects.SetActive(false);
            Tutorial6Objects.SetActive(false);
        }
        else if (tutorialStep == 3)
        {
            Tutorial3Objects.SetActive(true);
            Tutorial3Text.SetActive(true);
            Tutorial1Objects.SetActive(false);
            Tutorial2Objects.SetActive(false);
            Tutorial4Objects.SetActive(false);
            Tutorial5Objects.SetActive(false);
            Tutorial6Objects.SetActive(false);
        }
        else if (tutorialStep == 4)
        {
            Tutorial4Objects.SetActive(true);
            Tutorial1Objects.SetActive(false);
            Tutorial2Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial3Text.SetActive(false);
            Tutorial5Objects.SetActive(false);
            Tutorial6Objects.SetActive(false);
        }
        else if (tutorialStep == 5)
        {
            Tutorial5Objects.SetActive(true);
            Tutorial1Objects.SetActive(false);
            Tutorial2Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial3Text.SetActive(false);
            Tutorial4Objects.SetActive(false);
            Tutorial6Objects.SetActive(false);
        }
        else if (tutorialStep == 6)
        {
            Tutorial6Objects.SetActive(true);
            Tutorial1Objects.SetActive(false);
            Tutorial2Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial3Text.SetActive(false);
            Tutorial4Objects.SetActive(false);
            Tutorial5Objects.SetActive(false);
        }
        else
        {
            Tutorial1Objects.SetActive(false);
            Tutorial2Objects.SetActive(false);
            Tutorial3Objects.SetActive(false);
            Tutorial3Text.SetActive(false);
            Tutorial4Objects.SetActive(false);
            Tutorial5Objects.SetActive(false);
            Tutorial6Objects.SetActive(false);
        }
    }
}
