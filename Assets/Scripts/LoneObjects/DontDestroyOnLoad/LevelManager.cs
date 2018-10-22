using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }
    public void YouWin()
    {
        SceneManager.LoadScene("WinScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
