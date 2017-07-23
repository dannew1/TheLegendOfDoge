using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EscapePortal : MonoBehaviour {

    //public GameObject levelManager;
    public DontDestroyOnLoadConector levelManager;
    // Use this for initialization

    void Start () {
	    //changeSceneScript = levelManager.GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Doge>())
        {
            levelManager.GameOver(true);
        }
    }
}
