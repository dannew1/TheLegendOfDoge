using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireballMod : MonoBehaviour {

    public int modtype;
    public int modPriority;
    public bool activeStatus = true;
    private Fireball fireballScript;

    protected GameObject player;
    protected Doge dogeScript;
    protected Rigidbody2D rigid;

    private void ConnectMod()
    {
        fireballScript = GetComponent<Fireball>();
        fireballScript.ActiveModList.Add(this);
    }

    public void GetPlayer(GameObject doge)
    {
        rigid = GetComponent<Rigidbody2D>();
        player = doge;
        dogeScript = player.GetComponent<Doge>();
    }

    private void OnEnable()
    {
        ConnectMod();
    }

    public abstract void ModStart();

    public abstract void ModUpdate();

    public abstract void ModTriggerEnter();

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public abstract void Initialize();
}
