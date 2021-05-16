using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DanceFloorEffect : MonoBehaviour
{
    Tilemap danceFloor;
    float time;
    void Start()
    {
        time = 0.5f;
        danceFloor = gameObject.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            danceFloor.color = new Color(Random.value, Random.value, Random.value);
            time = 0.5f;
        }
        else
            time -= Time.deltaTime;
    }

}
