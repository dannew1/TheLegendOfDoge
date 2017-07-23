using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{

    public Doge player;

    private DogeHealth dogeHealthScript;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        dogeHealthScript = player.GetComponent<DogeHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = new Color(1, 1 - player.healthValue / dogeHealthScript.maxHealth, 1 - player.healthValue / dogeHealthScript.maxHealth, 1);
    }
}
