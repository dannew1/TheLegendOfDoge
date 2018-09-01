using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireballMod : MonoBehaviour {

    public int modType;
    public int modPriority;
    private Fireball fireballScript;

    protected float currentManaUsage;
    protected float currentReloadTime;

    protected GameObject player;
    protected Doge dogeScript;
    protected Rigidbody2D rigid;

    protected float shootingSpeed = 300;

    private void OnEnable()
    {
        ConnectMod();
    }

    private void ConnectMod()
    {
        fireballScript = GetComponent<Fireball>();
        fireballScript.ActiveModList.Add(this);
    }

    private void Update()
    {
        fireballScript.UpdateStats(currentManaUsage, currentReloadTime);
    }

    public void GetPlayer(GameObject doge)
    {
        rigid = GetComponent<Rigidbody2D>();
        player = doge;
        dogeScript = player.GetComponent<Doge>();

        currentManaUsage = fireballScript.manaUsage;
        currentReloadTime = fireballScript.reloadTime;
    }


    public abstract void ModStart();

    public abstract void ModUpdate();

    public abstract void ModTriggerEnter();
}
