using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentStats : MonoBehaviour {

    public Doge player;
    public DDOLConnector playerStatsScript;
    public Image hpSprite;
    public Image spSprite;
    public Text hpText;
    public Text spText;
    public Text livesText;

    private Shooting shootingScript;
    private DogeHealth dogeHealthScript;

    // Use this for initialization
    void Start () {
        shootingScript = player.GetComponent<Shooting>();
        dogeHealthScript = player.GetComponent<DogeHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        hpSprite.color = new Color(1, 1 - player.healthValue / dogeHealthScript.maxHealth, 1 - player.healthValue / dogeHealthScript.maxHealth, 1);
        spSprite.color = new Color(1 - player.manaValue / shootingScript.maxMana, 1 - player.manaValue / shootingScript.maxMana, 1, 1);
        hpText.text = Mathf.Round(player.healthValue / dogeHealthScript.maxHealth * 100) + "%";
        spText.text = Mathf.Round(player.manaValue / shootingScript.maxMana * 100) + "%";
        livesText.text = "Lives left: " + playerStatsScript.currentPlayerLives;
    }

}
