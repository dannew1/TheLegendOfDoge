using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

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
