using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Doge : MonoBehaviour
{
    private Shooting shootingScript;
    private DogeHealth healthScript;
    private MoveDoge moveScript;
    private QuickStatEdit baseStats;

    public DDOLConnector ddolScript;

    public float healthValue;
    public bool dogeLookingRight = true;
    public float manaValue;
    public float maxManaValue;
    public Vector2 fireballReload;
    public Vector2 thundershieldReload;

    public Fireball activeFireball;
    public ThunderShield activeThundershield;

    public int hpStat;
    public int hpRegStat;
    public int spStat;
    public int spRegStat;
    public int livesLeft;

    public float baseMaxHp;
    public float baseHpRegen;
    public float baseMaxMana;
    public float baseManaRegen;
    public float baseAcceleration;
    public float baseTopSpeed;
    public float baseJumpHeight;

    public Vector2 currentBox;
    public Vector2 boxSize = new Vector2(93, 53);

    private void Awake()
    {
        shootingScript = GetComponent<Shooting>();
        healthScript = GetComponent<DogeHealth>();
        moveScript = GetComponent<MoveDoge>();
        baseStats = GetComponent<QuickStatEdit>();
        SetPlayerStats();
        SetBaseStats();
        ReturnValues();
    }

    // Use this for initialization
    void Start()
    {
        if(ddolScript.startPositon != Vector3.zero)
        {
            transform.position = ddolScript.startPositon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerStats();
        SetBaseStats();
        ReturnValues();
        currentBox = GetCurrentBox();
    }

    private Vector2 GetCurrentBox()
    {
        return new Vector2(
            (float)Math.Floor(
            (transform.position.x - boxSize.x / 2) / boxSize.x
            ) + 1,

            (float)Math.Floor(
            (transform.position.y - boxSize.y / 2) / boxSize.y
            ) + 1);
    }

    private void SetPlayerStats()
    {
        hpStat = ddolScript.playerHpStat;
        hpRegStat = ddolScript.playerHpReg;
        spStat = ddolScript.playerSpStat;
        spRegStat = ddolScript.playerSpReg;
        livesLeft = ddolScript.currentPlayerLives;
        activeFireball = ddolScript.ballPrefab;
        activeThundershield = ddolScript.shieldPrefab;
    }

    private void SetBaseStats()
    {
        baseMaxHp = baseStats.baseMaxHp;
        baseHpRegen = baseStats.baseHpRegen;
        baseMaxMana = baseStats.baseMaxMana;
        baseManaRegen = baseStats.baseManaRegen;
        baseAcceleration = baseStats.acceleration;
        baseTopSpeed = baseStats.topSpeed;
        baseJumpHeight = baseStats.jumpHeight;
    }

    private void ReturnValues()
    {
        dogeLookingRight = moveScript.ReturnMoveValues(1);

        healthValue = healthScript.ReturnHpValues(1);

        manaValue = shootingScript.ReturnMpValues(1);
        maxManaValue = shootingScript.ReturnMpValues(2);
        fireballReload = shootingScript.ReturnRelaod(1);
        thundershieldReload = shootingScript.ReturnRelaod(2);
    }

    public void GiveWeaponPrefab(Fireball ballPrefab, ThunderShield shieldPrefab, bool isFireball)
    {
        if(isFireball)
        {
            ddolScript.SaveWeaponPrefab(ballPrefab, activeThundershield);
            activeFireball = ballPrefab;
        }
        else if (isFireball == false)
        {
            ddolScript.SaveWeaponPrefab(activeFireball, shieldPrefab);
            activeThundershield = shieldPrefab;
        }
    }
    public void SaveState()
    {
        ddolScript.SaveGame(transform.position);
    }

    public void Invunerablility()
    {
        healthScript.InvunerableDoge();
    }
    public void DeactivateInvunerability()
    {
        healthScript.KillableDoge();
    }

    public void DogeIsDead()
    {
        if (livesLeft > 0)
        {
            ddolScript.EditStat(5, -1);
            ddolScript.NewGame();
        }
        else
        {
            ddolScript.EditStat(5, 3);
            ddolScript.GameOver(false);
        }
    }
}