using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Doge player;

    private Vector3 offset;

    void Start()
    {
        //player = GetComponent<Doge>();

        offset = transform.position - player.transform.position;
        Debug.Log(player);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}