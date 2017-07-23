using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float playerHpStat;
    public float playerHpReg;
    public float playerSpStat;
    public float playerSpReg;
    
    private static LevelManager instance = null;
    
    void Start()
    {
        playerHpStat = 1;
        playerHpReg = 1;
        playerSpStat = 1;
        playerSpReg = 1;
    }

    public static LevelManager Instance
    {
        get { return instance; }
    }
    
    void Awake()
    {
    
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Scene");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }
    public void YouWin()
    {
        SceneManager.LoadScene("WinScene");
    }
}
