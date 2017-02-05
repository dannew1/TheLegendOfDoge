using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{

    public Doge player;

    private SpriteRenderer picture;

    // Use this for initialization
    void Start()
    {
        picture = GetComponent<SpriteRenderer>();
        //Object.FindObjectOfType<MainBossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        picture.color = new Color(1, 1 - player.healthValue / player.maxHealth, 1 - player.healthValue / player.maxHealth, 1);
    }
}
