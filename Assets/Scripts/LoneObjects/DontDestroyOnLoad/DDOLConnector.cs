using UnityEngine;
using System.Collections;

public class DDOLConnector : MonoBehaviour {

    public float playerHpStat;
    public float playerHpReg;
    public float playerSpStat;
    public float playerSpReg;
    public float currentPlayerLives;

    private DontDestroyOnLoad dontDestroyOnLoad;
    private LevelManager levelManager;
    private PlayerStats playerStats;
    private MusicPlayer musicPlayer;

    // Use this for initialization

    void Awake()
    {
        dontDestroyOnLoad = GameObject.FindObjectOfType<DontDestroyOnLoad>();
        levelManager = dontDestroyOnLoad.GetComponent<LevelManager>();
        playerStats = dontDestroyOnLoad.GetComponent<PlayerStats>();
        musicPlayer = dontDestroyOnLoad.GetComponent<MusicPlayer>();
    }

    void Start () {
	
	}

	void Update () {
        
        UpdatePlayerStat();
    }

    

    private void UpdatePlayerStat()
    {
        playerHpStat = playerStats.playerHpStat;
        playerHpReg = playerStats.playerHpReg;
        playerSpStat = playerStats.playerSpStat;
        playerSpReg = playerStats.playerSpReg;
        currentPlayerLives = playerStats.currentPlayerLives;
    }

    public void AddStat(int stat)
    {
        if (stat == 1)
        {
            playerStats.playerHpStat += 1;
        }
        else if (stat == 2)
        {
            playerStats.playerHpReg += 1;
        }
        else if (stat == 3)
        {
            playerStats.playerSpStat += 1;
        }
        else if (stat == 4)
        {
            playerStats.playerSpReg += 1;
        }
    }



    public void NewGame()
    {
        levelManager.NewGame();
    }

    public void GameOver(bool dogeAlive)
    {
        if (dogeAlive == true)
        {
            playerStats.currentPlayerLives = 3;
            levelManager.YouWin();
        }
        else if (dogeAlive == false)
        {
            if(currentPlayerLives >= 1)
            {
                playerStats.currentPlayerLives -= 1;
                levelManager.NewGame();
            }
            else
            {
                playerStats.currentPlayerLives = 3;
                levelManager.GameOver();
            }
        }
    }
}
