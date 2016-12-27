using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    private AudioSource Level1;

	// Use this for initialization
	void Start () {

        Level1 = GetComponent<AudioSource>();

        //if (Level1 != null)
        Level1.Play();

        //Level1.playOnAwake = true;

        Debug.Log("hej");
    }
	
	// Update is called once per frame
	void Update () {

    }
}
