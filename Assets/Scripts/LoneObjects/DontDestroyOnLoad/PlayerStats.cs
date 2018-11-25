using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int playerHpStat;
    public int playerHpReg;
    public int playerSpStat;
    public int playerSpReg;
    public int currentPlayerLives;
    public Fireball fireballPrefab;
    public ThunderShield thunderShieldPrefab;
    public Fireball savedFireball;
    public ThunderShield savedThunderShield;
    public Vector3 savedPosition;

    private void Awake()
    {
        //playerHpStat = 1;
        //playerHpReg = 1;
        //playerSpStat = 1;
        //playerSpReg = 1;
        currentPlayerLives = 2;
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

	}
}
