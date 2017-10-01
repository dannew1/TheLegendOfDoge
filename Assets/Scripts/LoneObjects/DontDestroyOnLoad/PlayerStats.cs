using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int playerHpStat;
    public int playerHpReg;
    public int playerSpStat;
    public int playerSpReg;
    public int currentPlayerLives = 3;

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
