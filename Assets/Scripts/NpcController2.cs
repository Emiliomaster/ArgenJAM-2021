using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcController2 : MonoBehaviour
{
    public Slider angerSlider;
    public Slider infectedSlider;

    public int health;
    public float speedInfected;
    public int selectSite;
    Vector3 curretPos;

    public float timeInPlace;
    public float[] countTime;

    public GameObject[] positionsSite;
    public GameObject[] sites;
    public bool inSite;
    public bool noSite;

    GameObject placeRef;
    Vector2 directionLook;
    bool posStateSpt;
    public float waitTimeMin;
    public float waitTimeMax;

    SpriteRenderer chilSpriteRef;
    Color colorInfected;
    Color colorNormal;
    bool isInfected;


    public int states;
    int posInArray;

    void Start()
    {
        speedInfected = 3f;
        chilSpriteRef = GetComponentInChildren<SpriteRenderer>();
        colorNormal = chilSpriteRef.color; 
        colorInfected = new Color(0, 1, 0); //verde

        angerSlider = GameObject.FindGameObjectWithTag("AngerSlider").GetComponent<Slider>();
        infectedSlider = GameObject.FindGameObjectWithTag("InfectionSlider").GetComponent<Slider>();

        waitTimeMin = 5;
        waitTimeMax = 8;
        timeInPlace = Random.Range(waitTimeMin, waitTimeMax);
        curretPos = transform.position;
        sites = GameObject.FindGameObjectsWithTag("Site");
    }

    void Update()
    {
        switch (states)
        {
            case 0: //sano
                if (!noSite)
                {
                    placeRef = SelectPosition();
                    noSite = true;
                }
                else
                {
                    GoToPlace(placeRef);
                }
                break;
            case 1: //Infectado
                chilSpriteRef.material.color = colorInfected;
                if (!noSite)
                {
                    placeRef = SelectPosition();
                    noSite = true;
                }
                else
                {
                    GoToPlace(placeRef);
                }
                if (health <= 0)
                {
                    infectedSlider.value--;
                    states = 2;
                }
                break;
            case 2://Inmune
                chilSpriteRef.material.color = colorNormal;
                if (!noSite)
                {
                    placeRef = SelectPosition();
                    noSite = true;
                }
                else
                {
                    GoToPlace(placeRef);
                }
                break;
            default:
                break;
        }

    }

    GameObject SelectPosition()
    {
        GameObject posRef = gameObject;
        selectSite = Random.Range(0, sites.Length);
        if (sites[selectSite].GetComponent<InfectionSites>().isFull)
        {
            selectSite = Random.Range(0, sites.Length);
        }
        else
        {
            positionsSite = sites[selectSite].GetComponent<InfectionSites>().positions;
            //Debug.Log("Busca en: " + sites[selectSite].name);

            for (int i = 0; i <= positionsSite.Length-1; ++i)
            {
                if (!inSite)
                {
                    posStateSpt = positionsSite[i].GetComponent<PositionState>().fullPosition;
                    if (!posStateSpt)//Si esa posicion esta libre
                    {
                        //Debug.Log("Encontro lugar: " + pos.name);
                        posRef = positionsSite[i].gameObject;
                        positionsSite[i].GetComponent<PositionState>().fullPosition = true;
                        posInArray = i;
                        break;
                    }
                }

            }

        }
        return posRef;
    }

    void GoToPlace(GameObject posRef)
    {
        directionLook = new Vector2(sites[selectSite].gameObject.transform.position.x - transform.position.x,
                                    sites[selectSite].gameObject.transform.position.y - transform.position.y);
        transform.up = directionLook;
        curretPos = Vector2.MoveTowards(transform.position, posRef.transform.position, speedInfected * Time.deltaTime);
        transform.position = curretPos;
        if (transform.position == posRef.transform.position)
        {
            inSite = true;
        }
        if (inSite)
        {
            if( timeInPlace <= 0)
            {
                timeInPlace = Random.Range(waitTimeMin, waitTimeMax);
                inSite = false;
                noSite = false;
                positionsSite[posInArray].GetComponent<PositionState>().fullPosition = false;
            }
            else
            {
                timeInPlace -= Time.deltaTime;
            }
        }
    }
}
