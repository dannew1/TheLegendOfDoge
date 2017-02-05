using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    private AudioSource Level1;

    private static MusicPlayer instance = null;

    public static MusicPlayer Instance
    {
        get { return instance; }
    }
    void Awake()
    {
    
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

void Start () {

        Level1 = GetComponent<AudioSource>();

        //if (Level1 != null)
        Level1.Play();

        //Level1.playOnAwake = true;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
