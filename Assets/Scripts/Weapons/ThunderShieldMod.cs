using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThunderShieldMod : MonoBehaviour {

    public int modType;
    public int modPriority;
    private ThunderShield thunderShieldscript;

    protected float currentManaUsage;
    protected float currentReloadTime;

    protected GameObject player;
    protected Doge dogeScript;
    protected Rigidbody2D rigid;

    protected bool hitEnemy;

    private void OnEnable()
    {
        ConnectMod();
    }

    private void ConnectMod()
    {
        thunderShieldscript = GetComponent<ThunderShield>();
        thunderShieldscript.ActiveModList.Add(this);
        
    }

    private void Update()
    {
        thunderShieldscript.UpdateStats(currentManaUsage, currentReloadTime);
    }

    public void GetPlayer(GameObject doge)
    {
        rigid = GetComponent<Rigidbody2D>();
        player = doge;
        dogeScript = player.GetComponent<Doge>();

        currentManaUsage = thunderShieldscript.manaUsage;
        currentReloadTime = thunderShieldscript.reloadTime;
    }

    public abstract void ModStart();

    public abstract void ModUpdate();

    public abstract void ModTriggerEnter();

    public abstract void ModKillThis();

    public abstract void ModOnDestroy();
}
