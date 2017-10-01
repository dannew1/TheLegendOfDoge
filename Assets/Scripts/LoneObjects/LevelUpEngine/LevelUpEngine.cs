using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUpEngine : MonoBehaviour {

    public DDOLConnector playerStats;

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
        HpStatText.text = "Hp Stat: " + playerStats.playerHpStat;
        HpRegText.text = "Hp Reg: " + playerStats.playerHpReg;
        SpStatText.text = "Sp Stat: " + playerStats.playerSpStat;
        SpRegText.text = "Sp Reg: " + playerStats.playerSpReg;
    }

    public void UpgradeStat(int stat)
    {
        if (stat == 1)
        {
            playerStats.EditStat(1, 1);
        }
        else if (stat == 2)
        {
            playerStats.EditStat(2, 1);
        }
        else if (stat == 3)
        {
            playerStats.EditStat(3, 1);
        }
        else if (stat == 4)
        {
            playerStats.EditStat(4, 1);
        }
    }
}
