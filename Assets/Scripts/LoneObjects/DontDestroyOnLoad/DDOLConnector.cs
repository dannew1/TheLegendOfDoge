using UnityEngine;
using System.Collections;

public class DDOLConnector : MonoBehaviour {

    public int playerHpStat;
    public int playerHpReg;
    public int playerSpStat;
    public int playerSpReg;
    public int currentPlayerLives;
    public Fireball ballPrefab;
    public ThunderShield shieldPrefab;

    private DontDestroyOnLoad dontDestroyOnLoad;
    private LevelManager levelManager;
    private PlayerStats playerStats;
    private MusicPlayer musicPlayer;

    public Vector3 startPositon;

    // Use this for initialization

    void Awake()
    {
        dontDestroyOnLoad = GameObject.FindObjectOfType<DontDestroyOnLoad>();
        levelManager = dontDestroyOnLoad.GetComponent<LevelManager>();
        playerStats = dontDestroyOnLoad.GetComponent<PlayerStats>();
        musicPlayer = dontDestroyOnLoad.GetComponent<MusicPlayer>();
        startPositon = playerStats.savedPosition;
        SaveWeaponPrefab(playerStats.savedFireball, playerStats.savedThunderShield);
        UpdatePlayerStat();
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
        ballPrefab = playerStats.fireballPrefab;
        shieldPrefab = playerStats.thunderShieldPrefab;
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

    public void SaveWeaponPrefab(Fireball ball, ThunderShield shield)
    {
        playerStats.fireballPrefab = ball;
        playerStats.thunderShieldPrefab = shield;
    }

    public void ResetSavedPosition()
    {
        playerStats.savedPosition = Vector3.zero;
    }

    public void SaveGame(Vector3 dogePosition)
    {
        playerStats.savedFireball = playerStats.fireballPrefab;
        playerStats.savedThunderShield= playerStats.thunderShieldPrefab;
        playerStats.savedPosition = dogePosition;
    }

    public void NewGame()
    {
        SaveWeaponPrefab(null, null);

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
                SaveWeaponPrefab(null, null);
                levelManager.Retry();
            }
            else
            {
                playerStats.currentPlayerLives = 3;
                levelManager.GameOver();
            }
        }
    }

    public void StartScene()
    {
        levelManager.MainMenu();
    }
}
