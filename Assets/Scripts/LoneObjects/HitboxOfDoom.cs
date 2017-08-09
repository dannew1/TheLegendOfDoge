using UnityEngine;
using System.Collections;

public class HitboxOfDoom : MonoBehaviour {

    public DDOLConnector levelManager;

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
            levelManager.GameOver(false);
        }
        else
        {
            Destroy(other_obj);
        }
    }
}
