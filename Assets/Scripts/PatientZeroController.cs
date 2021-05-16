using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientZeroController : MonoBehaviour
{
    public int health;
    public float speed;
    public int selectSite;
    Vector3 curretPos;
    public float timeInPlace;

    public GameObject[] positionsSite;
    public GameObject[] sites;

    public bool inSite;
    public bool noSite;
    GameObject placeRef;
    Vector2 directionLook;
    bool posStateSpt;
    public float waitTimeMin;
    public float waitTimeMax;
    int posInArray;

    Transform exitRef;


    void Start()
    {
        health = 4;
        speed = 2f;
        waitTimeMin = 10;
        waitTimeMax = 50;
        timeInPlace = Random.Range(waitTimeMin, waitTimeMax);
        curretPos = transform.position;
        sites = GameObject.FindGameObjectsWithTag("Site");
        exitRef = GameObject.FindGameObjectWithTag("Exit").transform;

    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, exitRef.position, speed * Time.deltaTime);
            directionLook = new Vector2(sites[selectSite].gameObject.transform.position.x - transform.position.x,
                                        sites[selectSite].gameObject.transform.position.y - transform.position.y);
            transform.up = directionLook;
            //---------------->GANASTE<---------------
            Debug.Log("Ganaste KPO!");
        }
        else
        {
            if (!noSite)
            {
                placeRef = SelectPosition();
                noSite = true;
            }
            else
            {
                GoToPlace(placeRef);
            }
        }
    }

    void GoToPlace(GameObject posRef)
    {
        directionLook = new Vector2(sites[selectSite].gameObject.transform.position.x - transform.position.x,
                                    sites[selectSite].gameObject.transform.position.y - transform.position.y);
        transform.up = directionLook;
        curretPos = Vector2.MoveTowards(transform.position, posRef.transform.position, speed * Time.deltaTime);
        transform.position = curretPos;
        if (transform.position == posRef.transform.position)
        {
            inSite = true;
        }
        if (inSite)
        {
            if (timeInPlace <= 0)
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

            for (int i = 0; i <= positionsSite.Length - 1; ++i)
            {
                if (!inSite)
                {
                    posStateSpt = positionsSite[i].GetComponent<PositionState>().fullPosition;
                    if (!posStateSpt)//Si esa posicion esta libre
                    {
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
}
