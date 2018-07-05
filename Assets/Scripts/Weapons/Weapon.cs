using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float damage;
    public float baseManaUsage;
    public float reloadTime;

    protected GameObject player;
    protected Doge dogeScript;
    protected Rigidbody2D rigid;

    protected void StartUp(GameObject doge)
    {
        rigid = GetComponent<Rigidbody2D>();

        player = doge;
        dogeScript = player.GetComponent<Doge>();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}

    //public Vector3 GetReturn()
    //{
    //    return new Vector3(damage, manaUsage, reloadTime);
    //}
}
