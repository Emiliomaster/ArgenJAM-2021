using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusController : MonoBehaviour
{
    public Slider infectionSlider;

    public GameObject[] people;
    public List<GameObject> infectedNpcsList;



    int posArry;
    int amountNpc;

    public float timeSpread;
    void Start()
    {
        timeSpread = 5f;
        people = GameObject.FindGameObjectsWithTag("NPC");

        infectionSlider = GameObject.FindGameObjectWithTag("InfectionSlider").GetComponent<Slider>();
        infectionSlider.maxValue = people.Length;
    }


    void FixedUpdate()
    {
        if (timeSpread <= 0)
        {
            Spread();
            timeSpread = 2f;
        }
        else
            timeSpread -= Time.deltaTime;
    }

    //void appendPeople()
    //{
    //    foreach (GameObject npc in people)
    //    {
    //        if(npc.GetComponent<NpcController2>().states == 2)
    //        {
    //            //infectedNpcsList.Remove(npc);
    //            Debug.Log("Se curo a un NPC: " + npc.name);
    //            infectionSlider.value--;
    //        }
    //    }
    //}

    void Spread()
    {
        amountNpc = Random.Range(3, 7);
        for (int i = 0; i <= amountNpc - 1; i++)
        {
            posArry = Random.Range(0, people.Length - 1);
            if(people[posArry].GetComponent<NpcController2>().states == 0)
            {
                people[posArry].GetComponent<NpcController2>().states = 1;
                infectionSlider.value++; 
            }
        }
    }
}
