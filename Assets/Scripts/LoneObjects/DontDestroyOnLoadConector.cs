using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadConector : MonoBehaviour {

    public float playerHpStat;
    public float playerHpReg;
    public float playerSpStat;
    public float playerSpReg;

    private LevelManager levelManager;

    // Use this for initialization

    void Awake()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePlayerStat();
    }

    private void UpdatePlayerStat()
    {
        playerHpStat = levelManager.playerHpStat;
        playerHpReg = levelManager.playerHpReg;
        playerSpStat = levelManager.playerSpStat;
        playerSpReg = levelManager.playerSpReg;
    }



    public void NewGame()
    {
        levelManager.NewGame();
    }

    public void GameOver(bool dogeAlive)
    {
        if (dogeAlive == true)
        {
            levelManager.YouWin();
        }
        else if (dogeAlive == false)
        {
            levelManager.GameOver();
        }
        
    }
    public void AddStat(int stat)
    {
        if (stat == 1)
        {
            levelManager.playerHpStat += 1;
        }
        else if (stat == 2)
        {
            levelManager.playerHpReg += 1;
        }
        else if (stat == 3)
        {
            levelManager.playerSpStat += 1;
        }
        else if (stat == 4)
        {
            levelManager.playerSpReg += 1;
        }
    }
}
