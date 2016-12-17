using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EscapePortal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Doge>())
        {
            //Destroy(gameObject);
            SceneManager.LoadScene("WinScene");
        }
    }
}
