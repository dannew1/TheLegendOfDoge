using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUpEngine : MonoBehaviour {

    public DontDestroyOnLoadConector levelManager;

    public Text HpStatText;
    public Text HpRegText;
    public Text SpStatText;
    public Text SpRegText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateText();
    }

    private void UpdateText()
    {
        HpStatText.text = "Hp Stat: " + levelManager.playerHpStat;
        HpRegText.text = "Hp Reg: " + levelManager.playerHpReg;
        SpStatText.text = "Sp Stat: " + levelManager.playerSpStat;
        SpRegText.text = "Sp Reg: " + levelManager.playerSpReg;
    }

    public void UpgradeStat(int stat)
    {
        if (stat == 1)
        {
            levelManager.AddStat(1);
        }
        else if (stat == 2)
        {
            levelManager.AddStat(2);
        }
        else if (stat == 3)
        {
            levelManager.AddStat(3);
        }
        else if (stat == 4)
        {
            levelManager.AddStat(4);
        }
    }
}
