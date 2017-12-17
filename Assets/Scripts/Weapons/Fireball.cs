using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    private Weapon weaponScript;
    private Rigidbody2D rigid;

    public static float reloadTime = 1.2f;
    public static float manaUsage = 20;
    public static float shootingSpeed = 300;
    public static float damage = 40;

    // Use this for initialization

    public void Initialize()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start () {
        weaponScript = GetComponent<Weapon>();
        weaponScript.SetDamageToDeal(damage);
    }

	void Update () {
	    
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>())
        {
            Destroy(gameObject);
        }
    }

    public void setSpeed(float speed)
    {
        rigid.velocity = new Vector2(speed * shootingSpeed, 0);
    }
}
