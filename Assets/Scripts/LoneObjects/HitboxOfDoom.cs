using UnityEngine;
using System.Collections;

public class HitboxOfDoom : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<GuyBullet>())
        {
            Destroy(other_obj);
        }
        else if(other_obj.GetComponent<Fireball>())
        {
            Destroy(other_obj);
        }
    }
}
