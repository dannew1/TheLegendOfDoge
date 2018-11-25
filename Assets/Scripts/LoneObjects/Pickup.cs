using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private bool isFireballPickup;
    private bool overlappingDoge = false;

    private bool isActive = true;

    public Fireball pickupFireball;
    public ThunderShield pickupThunderShield;

    private SpriteRenderer spriteChild;
    private Doge player;

	// Use this for initialization
	void Start () {

        spriteChild = transform.GetChild(0).GetComponent<SpriteRenderer>();

        player = FindObjectOfType<Doge>();

        if (pickupFireball != null)
        {
            isFireballPickup = true;
        }
        else if (pickupThunderShield != null)
        {
            isFireballPickup = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
        activatePickup();
    }

    

    private void activatePickup()
    {
        if((pickupFireball == player.activeFireball && isFireballPickup) || (pickupThunderShield == player.activeThundershield && !isFireballPickup))
        {
            isActive = false;
            spriteChild.sprite = null;
        }
        else
        {
            isActive = true;
            PreparePickup();
        }

        if (overlappingDoge == true && Input.GetKeyDown(KeyCode.X) && isActive)
        {
            player.GiveWeaponPrefab(pickupFireball, pickupThunderShield, isFireballPickup);
        }
    }

    private void PreparePickup()
    {
        if (isFireballPickup == true)
        {
            spriteChild.sprite = pickupFireball.GetComponent<SpriteRenderer>().sprite;
        }
        else if (isFireballPickup == false)
        {
            spriteChild.sprite = pickupThunderShield.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            spriteChild.sprite = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Doge>())
        {
            overlappingDoge = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Doge>())
        {
            overlappingDoge = false;
        }
    }
}
