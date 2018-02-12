using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    private AudioSource Level1;

    void Start () {

        Level1 = GetComponent<AudioSource>();

        //if (Level1 != null)
        Level1.Play();

        //Level1.playOnAwake = true;

    }
	
	// Update is called once per frame
	void Update () {
        MuteSound();
    }
    private void MuteSound()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(Level1.mute == true)
            {
                Level1.mute = false;
            }
            else if (Level1.mute == false)
            {
                Level1.mute = true;
            }
        }
    }
}
