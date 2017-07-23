using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatBar : MonoBehaviour {

    public int statType;
    public LevelUpEngine levelUpEngine;

    private DontDestroyOnLoadConector levelManager;
    private Image sprite;

    // Use this for initialization
    void Start () {
        levelManager = levelUpEngine.levelManager;
        sprite = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        sprite.color = SelectColor();
    }
    private Color SelectColor()
    {
        Color spriteColor;

        if(statType == 1)
        {
            spriteColor = new Color(1, 0.7f - levelManager.playerHpStat * 0.05f , 0.7f - levelManager.playerHpStat * 0.05f, 1);
            //spriteColor = new Color(1, 1 / 255 * (levelManager.playerHpStat*3), 1 / 255 * (levelManager.playerHpStat * 3), 1);
            //spriteColor = new Color(1, 1, 1, 1);
        }
        else if (statType == 2)
        {
            spriteColor = new Color(0.7f - levelManager.playerHpReg * 0.05f, 1, 0.7f - levelManager.playerHpReg * 0.05f, 1);
        }
        else if (statType == 3)
        {
            spriteColor = new Color(0.7f - levelManager.playerSpStat * 0.05f, 0.7f - levelManager.playerSpStat * 0.05f, 1, 1);
        }
        else if (statType == 4)
        {
            spriteColor = new Color(1, 1, 0.7f - levelManager.playerSpReg * 0.05f, 1);
        }
        else
        {
            spriteColor = new Color(0, 0, 0, 0);
        }

        return spriteColor;
    }
}
