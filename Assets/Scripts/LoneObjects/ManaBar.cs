using UnityEngine;
using System.Collections;

public class ManaBar : MonoBehaviour
{

    public Doge player;

    private Shooting shootingScript;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        shootingScript = player.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = new Color(1 - player.manaValue / shootingScript.maxMana, 1 - player.manaValue / shootingScript.maxMana, 1, 1);
    }
}