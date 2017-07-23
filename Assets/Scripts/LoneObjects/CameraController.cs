using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Doge player;
    public Vector2 min = new Vector2(200, 230);
    public Vector2 max = new Vector2(3450, 700);

    //private Vector3 offset;
    private float cameraX;
    private float cameraY;

    void Start()
    {
        //player = GetComponent<Doge>();

        //offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player.transform.position.x >= max.x)
            cameraX = max.x;
        else if (player.transform.position.x <= min.x)
            cameraX = min.x;
        else
            cameraX = player.transform.position.x;

        if (player.transform.position.y >= max.y)
            cameraY = max.y;
        else if (player.transform.position.y <= min.y)
            cameraY = min.y;
        else
            cameraY = player.transform.position.y;

        transform.position = new Vector3 (cameraX, cameraY, player.transform.position.z - 10);
        
    }
}