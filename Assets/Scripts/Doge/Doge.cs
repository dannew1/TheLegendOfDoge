using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    private Shooting shootingScript;
    private DogeHealth healthScript;
    private MoveDoge moveScript;
    private QuickStatEdit baseStats;

    public float healthValue; 
    public float manaValue;
    public bool dogeLookingRight = true;
    
    public int hpStat = 1;
    public int hpRegStat = 1;
    public int spStat = 1;
    public int spRegStat = 1;
    public int livesLeft = 3;

    public DDOLConnector ddolScript;

    // Use this for initialization

    void Awake()
    {
        livesLeft = ddolScript.currentPlayerLives;
    }

    void Start()
    {
        //changeSceneScript = levelManager.GetComponent<LevelManager>();
        shootingScript = GetComponent<Shooting>();
        healthScript = GetComponent<DogeHealth>();
        moveScript = GetComponent<MoveDoge>();
        //baseStats = GetComponent<QuickStatEdit>();
    }

// Update is called once per frame
    void Update()
    {
        livesLeft = ddolScript.currentPlayerLives;
        SetLookingRight();
        SetHealthValue();
        SetManaValue();
    }

    private void SetLookingRight()
    {
        dogeLookingRight = moveScript.isDogeLookingRight;
    }

    private void SetHealthValue()
    {
        healthValue = healthScript.health;
    }

    private void SetManaValue()
    {
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