using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Scene");
    }
}
