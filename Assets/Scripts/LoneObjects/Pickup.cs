using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private bool isFireballPickup;
    private bool overlappingDoge = false;

    public Fireball pickupFireball;
    public ThunderShield pickupThunderShield;

    private SpriteRenderer spriteChild;
    private Doge player;

	// Use this for initialization
	void Start () {

        spriteChild = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (pickupFireball != null)
        {
            isFireballPickup = true;
            spriteChild.sprite = pickupFireball.GetComponent<SpriteRenderer>().sprite;
        }
        else if(pickupThunderShield != null)
        {
            isFireballPickup = false;
            spriteChild.sprite = pickupThunderShield.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            spriteChild.sprite = null;
        }
	}
	
	// Update is called once per frame
	void Update () {
        activatePickup();
    }

    private void activatePickup()
    {
        if (overlappingDoge == true && Input.GetKeyDown(KeyCode.X) && (pickupFireball || pickupThunderShield))
        {
            player.GiveWeaponPrefab(pickupFireball, pickupThunderShield, isFireballPickup);
            spriteChild.sprite = null;
            pickupFireball = null;
            pickupThunderShield = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Doge>())
        {
            overlappingDoge = true;
            player = collider.gameObject.GetComponent<Doge>();
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
