using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryText : MonoBehaviour {

    public TextAsset normalText;
    public TextAsset var1Text;
    public TextAsset var2Text;
    private string[] normalStrings;
    private string[] var1Strings;
    private string[] var2Strings;

    private Text storyText;
    private bool inStory = false;
    private int lastReadText;
    private int numberOfStrings = 0;

    public bool GetInStory()
    {
        return inStory;
    }

    // Use this for initialization
    void Start () {
        storyText = FindObjectOfType<MovingText>().GetComponent<Text>();

        normalStrings = SplitString(normalText);
        var1Strings = SplitString(var1Text);
        var2Strings = SplitString(var2Text);
    }

    private string[] SplitString(TextAsset txt)
    {
        if(txt != null)
        {
            return txt.text.Split('\n');
        }
        return null;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartText()
    {
        inStory = true;
        numberOfStrings = 0;
        foreach (string s in normalStrings)
        {
            numberOfStrings++;
        }
        ShowText(0, normalStrings);
    }

    public void ContinueText()
    {
        ShowText(lastReadText + 1, normalStrings);
    }

    public void ClearText()
    {
        storyText.text = "";
        inStory = false;
    }

    public void InterruptText()
    {
        ClearText();
    }

    private void ShowText(int toRead, string[] strings)
    {
        if (toRead < numberOfStrings)
        {
            storyText.text = strings[toRead];
            lastReadText = toRead;
        }
        else
        {
            ClearText();
        }
    }

    /// //////////////////////////////////////////////////////////////////
    //Unused

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






}
