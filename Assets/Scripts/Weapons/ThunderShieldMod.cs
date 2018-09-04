using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThunderShieldMod : MonoBehaviour {

    public int modType;
    public int modPriority;
    private ThunderShield thunderShieldscript;

    protected float changeManaUsage = 0;
    protected float changeReloadTime = 0;

    protected GameObject player;
    protected Doge dogeScript;
    protected Rigidbody2D rigid;

    private void OnEnable()
    {
        Initialize();
        ConnectMod();
    }

    private void ConnectMod()
    {
        thunderShieldscript = GetComponent<ThunderShield>();
        thunderShieldscript.ActiveModList.Add(this);
    }

    private void Update()
    {
        thunderShieldscript.UpdateStats(changeManaUsage, changeReloadTime);
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
