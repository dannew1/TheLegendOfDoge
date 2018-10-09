using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("SceneTiled");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("SceneTiled");
    }
    public void YouWin()
    {
        SceneManager.LoadScene("SceneTiled");
    }
}
