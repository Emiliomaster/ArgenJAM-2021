using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    Vector3 posRef;
    float speed;
    GameObject playerRef;


    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        posRef = transform.position;
    }

    void Update()
    {
        ViewPlayer();
    }

    void ViewPlayer()
    {
        float posPlayerX;
        float posPlayerY;
        posPlayerX = playerRef.transform.position.x;
        posPlayerY = playerRef.transform.position.y;
        posRef.x = posPlayerX;
        posRef.y = posPlayerY;
        posRef.z = -15f;
        transform.position = posRef;
        transform.LookAt(playerRef.transform);
    }
}
