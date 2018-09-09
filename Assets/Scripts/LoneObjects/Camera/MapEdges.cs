using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapEdges : MonoBehaviour {

    private GameObject topR;
    private GameObject botL;

    public Vector2 offset = new Vector2(470, 280);
    // Use this for initialization

    void Start () {
        topR = gameObject.transform.GetChild(0).gameObject;
        botL = gameObject.transform.GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector2 MinMaxEdges(int setting)
    {
        if (setting == 1)
        {
            return new Vector2(botL.transform.position.x + offset.x, botL.transform.position.y + offset.y);
        }
        else if (setting == 2)
        {
            return new Vector2(topR.transform.position.x - offset.x, topR.transform.position.y - offset.y);
        }

        else
        {
            return new Vector2(0, 0);
        }
    }
}
