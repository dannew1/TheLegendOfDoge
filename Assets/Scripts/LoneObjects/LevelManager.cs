using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    //private static LevelManager instance = null;
    //
    //public static LevelManager Instance
    //{
    //    get { return instance; }
    //}
    //
    //void Awake()
    //{
    //
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
    //    else
    //    {
    //        instance = this;
    //    }
    //    DontDestroyOnLoad(this.gameObject);
    //}

    //MusicController music_controller = GameObject.FindObjectOfType<MusicController>();
    //music_controller.Mute();

    //if (Input.GetKeyDown(KeyCode.P)) {
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    //}

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
