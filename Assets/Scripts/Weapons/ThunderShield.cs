using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShield : MonoBehaviour {

    private Rigidbody2D rigid;
    private GameObject player;

    public static float reloadTime = 0;
    public static float manaUsage = 0.8F;
    public static float shootingSpeed = 200;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StickToPlayer();
    }

    public void SetPlayer(GameObject doge)
    {
        player = doge;
    }

    private void StickToPlayer()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
}
