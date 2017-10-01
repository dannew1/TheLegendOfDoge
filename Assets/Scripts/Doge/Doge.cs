using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    private Shooting shootingScript;
    private DogeHealth healthScript;
    private MoveDoge moveScript;

    public float healthValue; 
    public float manaValue;
    public float livesLeft = 3;
    public bool dogeLookingRight = true;

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
            ddolScript.GameOver(false);
        }
    }
}