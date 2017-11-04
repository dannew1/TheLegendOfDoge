using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    private Shooting shootingScript;
    private DogeHealth healthScript;
    private MoveDoge moveScript;
    private QuickStatEdit baseStats;

    public DDOLConnector ddolScript;

    public float healthValue; 
    public float manaValue;
    public bool dogeLookingRight = true;
    
    public int hpStat;
    public int hpRegStat;
    public int spStat;
    public int spRegStat;
    public int livesLeft;

    public float baseMaxHp;
    public float baseHpRegen;
    public float baseMaxMana;
    public float baseManaRegen;
    public float acceleration;
    public float topSpeed;
    public float jumpHeight;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerStats();
        SetBaseStats();
        ReturnValues();
    }

    private void SetPlayerStats()
    {
        hpStat = ddolScript.playerHpStat;
        hpRegStat = ddolScript.playerHpReg;
        spStat = ddolScript.playerSpStat;
        spRegStat = ddolScript.playerSpReg;
        livesLeft = ddolScript.currentPlayerLives;
    }

    private void SetBaseStats()
    {
        baseMaxHp = baseStats.baseMaxHp;
        baseHpRegen = baseStats.baseHpRegen;
        baseMaxMana = baseStats.baseMaxMana;
        baseManaRegen = baseStats.baseManaRegen;
        acceleration = baseStats.acceleration;
        topSpeed = baseStats.topSpeed;
        jumpHeight = baseStats.jumpHeight;
    }

    private void ReturnValues()
    {
        dogeLookingRight = moveScript.isDogeLookingRight;
        healthValue = healthScript.health;
        manaValue = shootingScript.mana;
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