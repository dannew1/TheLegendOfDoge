﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryText : MonoBehaviour {

    public TextAsset textFile;
    private string[] happyStrings;
    private string[] normalStrings;
    private string[] angryStrings;

    public Text storyText;
    public bool inStory = false;
    private Vector3 lastReadText;

    private bool finalTextShown = false;

    // Use this for initialization
    void Start () {
        string[] lines;
        lines = textFile.text.Split('\\' );
        happyStrings = lines[0].Split('\n');
        normalStrings = lines[1].Split('\n');
        angryStrings = lines[2].Split('\n');
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartText(int currentStage, int signRage)
    {
        int scenario = CurrentScenario(signRage, currentStage);
        ShowText(new Vector3(currentStage, scenario, 1));
    }

    public void ContinueText()
    {
        if(finalTextShown == true)
        {
            ClearText();
        }
        else
        {
            ShowText(new Vector3(lastReadText.x, lastReadText.y, lastReadText.z + 1));
        }
    }

    public void ClearText()
    {
        storyText.text = "";
        inStory = false;
        finalTextShown = false;
    }

    /// //////////////////////////////////////////////////////////////////

    private int CurrentScenario(int signRage, int currentStage)
    {
        Vector2 rage = StageRage(currentStage);

        if (signRage <= rage.x)
        {
            return 1;
        }
        else if (signRage >= rage.y)
        {
            return 3;
        }
        else
        {
            return 2;
        }
    }

    private Vector2 StageRage(int currentStage)
    {
        if(currentStage == 0)
        {
            return new Vector2(-1, 101);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }

    /// ///////////////////////////////////////////////////////////////////

    private void ShowText(Vector3 toRead)
    {
        if (toRead == new Vector3(0, 2, 1))
        {
            storyText.text = normalStrings[0];
            lastReadText = toRead;
            inStory = true;
        }

        if (toRead == new Vector3(0, 2, 2))
        {
            storyText.text = normalStrings[1];
            lastReadText = toRead;
            finalTextShown = true;
        }
    }







}