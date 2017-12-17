using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShield : MonoBehaviour {

    private Weapon weaponScript;
    private Rigidbody2D rigid;
    private GameObject player;
    private Doge dogeScript;

    public static float reloadTime = 0;
    public static float manaUsage = 2f;
    public static float shootingSpeed = 200;
    public static float damage = 100;

    public void Initialize(GameObject doge)
    {
        player = doge;
    }

    // Use this for initialization
    void Start () {
        weaponScript = GetComponent<Weapon>();
        weaponScript.SetDamageToDeal(damage);

        dogeScript = player.GetComponent<Doge>();
        DamageResist();
	}
	
	// Update is called once per frame
	void Update () {
        StickToPlayer();
    }

    private void OnDestroy()
    {
        NoDamageResist();
    }



    private void StickToPlayer()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }

    private void DamageResist()
    {
        dogeScript.Invunerablility();
    }
    
    private void NoDamageResist()
    {
        dogeScript.DeactivateInvunerability();
    }
}
