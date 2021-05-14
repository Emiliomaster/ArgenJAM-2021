using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionSites : MonoBehaviour
{
    public GameObject[] positions;
    public bool isFull;

    public int countFullPos;
    void Start()
    {
        TakePositions();
    }

    void Update()
    {
        CheckPositions();
    }

    void TakePositions()
    {
        for (int i = 0; i <= positions.Length-1; i++)
        {
            positions[i] = transform.GetChild(i).gameObject;
        }
    }

    void CheckPositions()
    {
        if (countFullPos >= positions.Length)
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }
    }
}
