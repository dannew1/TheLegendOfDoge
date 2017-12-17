using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentStats : MonoBehaviour {

    public Doge player;
    public Image hpSprite;
    public Image spSprite;
    public Image reloadSprite;
    public Text hpText;
    public Text spText;
    public Text weaponText;
    public Text livesText;

    //private Shooting shootingScript;
    //private DogeHealth dogeHealthScript;

    // Use this for initialization
    void Start () {
        //shootingScript = player.GetComponent<Shooting>();
        //dogeHealthScript = player.GetComponent<DogeHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        SetColors();
        SetText();
    }

    private void SetColors()
    {
        if (player.healthValue >= player.baseMaxHp)
        {
            hpSprite.color = new Color(1, 0, 0, 1);
        }
        else
        {
            hpSprite.color = new Color(1, 1 - player.healthValue / player.baseMaxHp, 1 - player.healthValue / player.baseMaxHp, 1);
        }

        if (player.manaValue >= player.baseMaxMana)
        {
            spSprite.color = new Color(0, 0.3f, 1, 1);
        }
        else
        {
            spSprite.color = new Color(1 - player.manaValue / player.baseMaxMana, 1.3f - player.manaValue / player.baseMaxMana, 1, 1);
        }

        if(player.reload <= 0)
        {
            reloadSprite.color = new Color(0, 1, 0, 1);
        }
        else
        {
            reloadSprite.color = new Color(player.reload + 0.2f, 1, player.reload + 0.2f, 1);
        }

        if (player.livesLeft == 0)
        {

            livesText.color = new Color(1, 0.39f, 0, 1);
        }
        else
        {
            livesText.color = new Color(0, 0, 0, 1);
        }
    }

    private void SetText()
    {
        hpText.text = Mathf.Round(player.healthValue / player.baseMaxHp * 100) + "%";
        spText.text = Mathf.Round(player.manaValue / player.baseMaxMana * 100) + "%";
        livesText.text = "Lives left: " + player.livesLeft;

        if(player.weapon == 1)
        {
            weaponText.text = "Fireball";
        }
        else if(player.weapon == 2)
        {
            weaponText.text = "ThunderShield";
        }

    }
}
