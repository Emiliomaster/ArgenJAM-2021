using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxLogic : MonoBehaviour
{

    public int maxAmmo = 12;
    public GameObject[] ammoBoxPositions;


    public float timer;
    public int positionRandom;
    public int ammoCount;
    void TakePositions()
    {
        for (int i = 0;i <= ammoBoxPositions.Length -1; i++)
        {
            ammoBoxPositions[i] = transform.GetChild(i).gameObject;
        }
    }

    void Start()
    {
        TakePositions();
        ammoCount = 1;
        timer = 10f;
    }

    void Update()
    {
        if (ammoCount > 0)
        {
            SelectAmmoBox();
        }
        else
        {
            Spawn();
        }
    }

    void SelectAmmoBox()
    {
        positionRandom = Random.Range(0, ammoBoxPositions.Length);
        ammoBoxPositions[positionRandom].SetActive(true);
        ammoCount--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string typeTag = col.gameObject.tag;
        switch (typeTag)
        {
            case "Player":
                if (col.gameObject.GetComponent<Shooting>().bulletCount < 12)
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    void Spawn()
    {
        if (ammoBoxPositions[positionRandom].activeInHierarchy == false)
        {
            if (timer > 0 )
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = 10f;
                ammoCount = 1;
            }
        }
    }
}
