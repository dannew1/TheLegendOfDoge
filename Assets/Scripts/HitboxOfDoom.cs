using UnityEngine;
using System.Collections;

public class Derp : MonoBehaviour
{

}

public class HitboxOfDoom : MonoBehaviour {

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
            changeSceneScript.GameOver();
        }
        else
        {
            Destroy(other_obj);
        }
    }
}
