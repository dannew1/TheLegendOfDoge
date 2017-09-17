using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public float playerHpStat;
    public float playerHpReg;
    public float playerSpStat;
    public float playerSpReg;
    public float currentPlayerLives;

    // Use this for initialization
    void Start () {
        playerHpStat = 1;
        playerHpReg = 1;
        playerSpStat = 1;
        playerSpReg = 1;
        currentPlayerLives = 3;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
