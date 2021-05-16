using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//IMPLEMENTO ESTE
public class VirusController : MonoBehaviour
{
    public Slider infectionSlider;

    public GameObject[] people;
    public List<GameObject> infectedNpcsList;

    int numWave;
    int numpy;
    public List<GameObject> wave1;
    public List<GameObject> wave2;
    public List<GameObject> wave3;

    public int minIntWave1 = 3;
    public int maxIntWave1 = 7;

    public int minIntWave2 = 5;
    public int maxIntWave2 = 9;

    public int minIntWave3 = 2;
    public int maxIntWave3 = 4;



    int amountNpc;
    public float timerWave;

    public int amountInfected;


    public float timeSpread;
    void Start()
    {
        timerWave = 10f;
        numWave = 1;
        timeSpread = 5f;
        people = GameObject.FindGameObjectsWithTag("NPC");
        infectionSlider = GameObject.FindGameObjectWithTag("InfectionSlider").GetComponent<Slider>();
        infectionSlider.maxValue = (people.Length * 50) / 100;
        LoadWave1();
        Debug.Log(wave1.Count);
    }


    void LoadWave1()
    {
        for (int i = 0; i <= people.Length - 1; i++)
        {
            wave1.Add(people[i]);
        }
    }

    void FixedUpdate()
    {
        //if (timeSpread <= 0)
        //{
        //    VirusWave();
        //    timeSpread = .5f;
        //}
        //else
        //    timeSpread -= Time.deltaTime;

        VirusWave();
    }

    void VirusWave()
    {
        int countNpcInfected;
        switch (numWave)
        {
            case 1:
                if (timeSpread <= 0)
                {
                    amountNpc = Random.Range(minIntWave1, maxIntWave1);
                    if (amountNpc > wave1.Count)
                        amountNpc = wave1.Count;

                    if (wave1.Count <= 0 && amountInfected <= 0)
                    {
                        numWave = 2;
                        Debug.Log("Cambio de wave");
                    }
                    else
                    {
                        int z = 0;
                        for (int i = 0; i <= amountNpc - 1; i++)
                        {
                            countNpcInfected = wave1[z].GetComponent<NpcController2>().countNpcState;
                            if (countNpcInfected <= 0)
                            {
                                //wave1[z].GetComponent<NpcController2>().countNpcState = 1;
                                wave1[z].GetComponent<NpcController2>().states = 1;
                                infectionSlider.value++;
                                amountInfected++;
                                wave2.Add(wave1[z]);
                                wave1.Remove(wave1[z]);
                            }
                        }
                    }
                    timeSpread = 5f;
                }
                else
                {
                    timeSpread -= Time.deltaTime;
                }
                break;
            case 2:
                if (timeSpread <= 0)
                {
                    amountNpc = Random.Range(minIntWave2, maxIntWave2);
                    if (amountNpc > wave2.Count)
                        amountNpc = wave2.Count;

                    if (wave2.Count <= 0 && amountInfected <= 0)
                    {
                        numWave = 3;
                        Debug.Log("Cambio de wave");
                        //timerWave = 10f;
                    }
                    else
                    {
                        int z = 0;
                        for (int i = 0; i <= amountNpc - 1; i++)
                        {
                            countNpcInfected = wave2[z].GetComponent<NpcController2>().countNpcState;
                            if (countNpcInfected <= 1)
                            {
                                //wave2[z].GetComponent<NpcController2>().countNpcState = 2;
                                wave2[z].GetComponent<NpcController2>().states = 1;
                                infectionSlider.value++;
                                amountInfected++;
                                wave3.Add(wave2[z]);
                                wave2.Remove(wave2[z]);
                            }
                        }
                    }
                    timeSpread = 5f;
                }
                else
                    timeSpread -= Time.deltaTime;
                break;
            case 3:
                if (timeSpread <= 0)
                {
                    amountNpc = Random.Range(minIntWave3, maxIntWave3);
                    if (amountNpc > wave3.Count)
                        amountNpc = wave3.Count;

                    if (wave3.Count <= 0 && amountInfected <= 0)
                    {
                        numWave = 4;
                    }
                    else
                    {
                        int z = 0;
                        for (int i = 0; i <= amountNpc - 1; i++)
                        {
                            countNpcInfected = wave3[z].GetComponent<NpcController2>().countNpcState;
                            if (countNpcInfected <= 2)
                            {
                                //wave3[z].GetComponent<NpcController2>().countNpcState = 3;
                                wave3[z].GetComponent<NpcController2>().states = 1;
                                infectionSlider.value++;
                                amountInfected++;
                                wave3.Remove(wave3[z]);
                            }
                        }
                    }
                    timeSpread = 5f;
                }
                else
                    timeSpread -= Time.deltaTime;
                break;
            default:
                break;
        }
    }

}