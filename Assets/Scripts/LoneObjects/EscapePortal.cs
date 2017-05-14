using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EscapePortal : MonoBehaviour {

    public GameObject levelManager;
    private ChangeScene changeSceneScript;

	// Use this for initialization
	void Start () {
	    changeSceneScript = levelManager.GetComponent<ChangeScene>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Doge>())
        {
            changeSceneScript.YouWin();
        }
    }
}
