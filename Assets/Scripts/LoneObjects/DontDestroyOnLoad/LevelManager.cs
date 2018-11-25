using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private float exitTimer;

    private void Update()
    {
        ExitGame();
    }


    public void NewGame()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Retry()
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

    private void ExitGame()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            exitTimer += Time.deltaTime;
            if(exitTimer >= 0.75f)
            {
                Application.Quit();
            }
        }
        else
        {
            exitTimer = 0;
        }
    }
}
