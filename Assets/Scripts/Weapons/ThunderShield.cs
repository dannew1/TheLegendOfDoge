using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShield : MonoBehaviour {

    private Rigidbody2D rigid;

    public static float reloadTime = 1;
    public static float manaUsage = 10;
    public static float shootingSpeed = 200;

    // Use this for initialization
    void Start () {
		
	}

    public void Initialize()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    

}
