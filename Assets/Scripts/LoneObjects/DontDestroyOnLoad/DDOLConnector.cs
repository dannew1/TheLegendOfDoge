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
        UpdatePlayerStat();
       
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

    public void EditStat(int stat, int value)
    {
        if (stat == 1)
        {
            playerStats.playerHpStat += value;
        }
        else if (stat == 2)
        {
            playerStats.playerHpReg += value;
        }
        else if (stat == 3)
        {
            playerStats.playerSpStat += value;
        }
        else if (stat == 4)
        {
            playerStats.playerSpReg += value;
        }
        else if (stat == 5)
        {
            playerStats.currentPlayerLives += value;
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
            levelManager.YouWin();
        }
        else if (dogeAlive == false)
        {
            levelManager.GameOver();
        }
        
    }
    
}
