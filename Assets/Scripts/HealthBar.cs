using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{

    public Doge player;
    private DogeHealth dogeHealthScript;

    private SpriteRenderer picture;

    // Use this for initialization
    void Start()
    {
        picture = GetComponent<SpriteRenderer>();
        dogeHealthScript = player.GetComponent<DogeHealth>();
        //Object.FindObjectOfType<MainBossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        picture.color = new Color(1, 1 - player.healthValue / dogeHealthScript.maxHealth, 1 - player.healthValue / dogeHealthScript.maxHealth, 1);
    }
}
