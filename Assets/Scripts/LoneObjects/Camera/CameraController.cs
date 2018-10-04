using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{

    public Doge player;
    public Vector2 boxSize = new Vector2(93, 53);

    //private Vector3 playerPos;
    private float cameraX;
    private float cameraY;


    void Start()
    {
        
    }

    void LateUpdate()
    {
        cameraX = ((float)Math.Floor(
            (player.transform.position.x-boxSize.x/2) / boxSize.x
            ) + 1) * boxSize.x;

        cameraY = ((float)Math.Floor(
            (player.transform.position.y - boxSize.y / 2) / boxSize.y
            ) + 1) * boxSize.y;
      
        transform.position = new Vector3 (cameraX, cameraY, player.transform.position.z - 100);
    }
}