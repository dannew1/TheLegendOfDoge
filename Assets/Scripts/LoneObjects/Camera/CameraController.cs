using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{

    public Doge player;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3 (
            player.currentBox.x * player.boxSize.x, 
            player.currentBox.y* player.boxSize.y, 
            player.transform.position.z - 100);
    }

    public bool CallFunction(Vector2 box)
    {
        if(box == player.currentBox)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}