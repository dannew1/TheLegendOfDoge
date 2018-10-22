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
}