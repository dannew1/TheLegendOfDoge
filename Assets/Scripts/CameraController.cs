using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Doge player;
    public float maxX = 800;
    public float minX = 200;
    public float maxY = 500;
    public float minY = 0;

    private Vector3 offset;
    private float cameraX;
    private float cameraY;

    void Start()
    {
        //player = GetComponent<Doge>();

        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player.transform.position.x >= maxX)
            cameraX = maxX;
        else if (player.transform.position.x <= minX)
            cameraX = minX;
        else
            cameraX = player.transform.position.x;

        if (player.transform.position.y >= maxY)
            cameraY = maxY;
        else if (player.transform.position.y <= minY)
            cameraY = minY;
        else
            cameraY = player.transform.position.y;

        transform.position = new Vector3 (cameraX, cameraY, player.transform.position.z) + offset;
        
    }
}