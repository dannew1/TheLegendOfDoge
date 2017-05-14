using UnityEngine;
using System.Collections;

public class ManaBar : MonoBehaviour
{

    public Doge player;

    private Shooting shootingScript;
    private SpriteRenderer picture;

    // Use this for initialization
    void Start()
    {
        picture = GetComponent<SpriteRenderer>();
        shootingScript = player.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        picture.color = new Color(1 - player.manaValue / shootingScript.maxMana, 1 - player.manaValue / shootingScript.maxMana, 1, 1);
    }
}