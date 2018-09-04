using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireballMod : MonoBehaviour {

    public int modType;
    public int modPriority;
    private Fireball fireballScript;

    protected float changeManaUsage = 0;
    protected float changeReloadTime = 0;

    protected GameObject player;
    protected Doge dogeScript;
    protected Rigidbody2D rigid;

    protected float shootingSpeed = 300;

    private void OnEnable()
    {
        Initialize();
        ConnectMod();
    }

    private void ConnectMod()
    {
        fireballScript = GetComponent<Fireball>();
        fireballScript.ActiveModList.Add(this);
    }

    private void Update()
    {
        fireballScript.UpdateStats(changeManaUsage, changeReloadTime);
        changeManaUsage = 0;
        changeReloadTime = 0;
    }

    public void GetPlayer(GameObject doge)
    {
        rigid = GetComponent<Rigidbody2D>();
        player = doge;
        dogeScript = player.GetComponent<Doge>();
    }

    public abstract void Initialize();

    public abstract void ModStart();

    public abstract void ModUpdate();

    public abstract void ModTriggerEnter();

    public abstract void ModTriggerExit();

    public abstract void ModKillThis();

    public abstract void ModOnDestroy();
}
