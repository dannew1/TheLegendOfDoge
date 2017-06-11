using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Doge : MonoBehaviour
{
    private Shooting shootingScript;
    private DogeHealth healthScript;
    private MoveDoge moveScript;

    public float healthValue; 
    public float manaValue;
    public bool dogeLookingRight = true;

    public GameObject levelManager;
    private LevelManager changeSceneScript;

    // Use this for initialization
    void Start()
    {
        Debug.Log(levelManager);
        Debug.Log(changeSceneScript);
        changeSceneScript = levelManager.GetComponent<LevelManager>();
        shootingScript = GetComponent<Shooting>();
        healthScript = GetComponent<DogeHealth>();
        moveScript = GetComponent<MoveDoge>();
        Debug.Log(levelManager);
        Debug.Log(changeSceneScript);
    }

// Update is called once per frame
    void Update()
    {
        
        SetLookingRight();
        SetHealthValue();
        SetManaValue();

    }

    private void SetLookingRight()
    {
        dogeLookingRight = moveScript.isDogeLookingRight;
    }

    private void SetHealthValue()
    {
        healthValue = healthScript.health;
    }

    private void SetManaValue()
    {
        manaValue = shootingScript.mana;
    }
}