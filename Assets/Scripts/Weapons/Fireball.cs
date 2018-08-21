using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fireball : UserWeapon {

    private static float shootingSpeed = 300;
    private List<FireballMod> ActiveModList;

    public override void Initialize(GameObject i)
    {
        damage = 20;
        manaUsage = 200;
        reloadTime = 1.2f;

        StartUp(i);
    }

    void Start () {
        SetSpeed();
    }

    void Update () {
        
	}

    public override void KillThis()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            Destroy(gameObject);
        }
    }

    private void SetSpeed()
    {
        if (dogeScript.dogeLookingRight == false)
        {
            rigid.velocity = new Vector2(-shootingSpeed, 0);
        }
        else if (dogeScript.dogeLookingRight == true)

        {
            rigid.velocity = new Vector2(shootingSpeed, 0);
        }
    }
}
