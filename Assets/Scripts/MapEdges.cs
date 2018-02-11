using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapEdges : MonoBehaviour {

    public GameObject topR;
    public GameObject botL;

    public Vector2 maxCamera;
    public Vector2 minCamera;

    // Use this for initialization
    void Awake()
    {
        maxCamera = topR.transform.position;
        minCamera = botL.transform.position;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
