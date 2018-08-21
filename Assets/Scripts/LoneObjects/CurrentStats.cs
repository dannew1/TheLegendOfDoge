using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentStats : MonoBehaviour {

    public Doge player;
    public Image hpSprite;
    public Image hpSprite2;
    public Image hpSprite3;
    public Image spSprite;
    public Image spSprite2;
    public Image spSprite3;
    public Image reloadSprite1;
    public Image reloadSprite2;
    public Text hpText;
    public Text spText;
    public Text livesText;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        SetColors();
        SetFill();
        SetText();
    }

    private void SetColors()
    {
        if (player.livesLeft == 0)
        {

            livesText.color = new Color(1, 0.39f, 0, 1);
        }
        else
        {
            livesText.color = new Color(0, 0, 0, 1);
        }
    }

    private void SetFill()
    {
        hpSprite.fillAmount = player.healthValue / player.baseMaxHp;
        hpSprite2.fillAmount = (player.healthValue - player.baseMaxHp) / player.baseMaxHp;
        hpSprite3.fillAmount = (player.healthValue - 2*player.baseMaxHp) / player.baseMaxHp;

        spSprite.fillAmount = player.manaValue / player.baseMaxMana;
        spSprite2.fillAmount = (player.manaValue - player.baseMaxMana) / player.baseMaxMana;
        spSprite3.fillAmount = (player.manaValue - 2 * player.baseMaxMana) / player.baseMaxMana;

        if (player.fireballReload.x <= 0)
        {
            reloadSprite1.fillAmount = 1;
        }
        else
        {
            reloadSprite1.fillAmount = 1 - (player.fireballReload.x / player.fireballReload.y);
        }

        if (player.thundershieldReload.x <= 0)
        {
            reloadSprite2.fillAmount = 1;
        }
        else
        {
            reloadSprite2.fillAmount = 1 - (player.thundershieldReload.x / player.thundershieldReload.y);
        }
    }

    private void SetText()
    {
        hpText.text = Mathf.Round(player.healthValue / 10) + "%";
        spText.text = Mathf.Round(player.manaValue / 10) + "%";
        livesText.text = "Lives left: " + player.livesLeft;

    }
}
