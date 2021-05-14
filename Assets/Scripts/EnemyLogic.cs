using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyLogic : MonoBehaviour
{
    public int health = 2;
    public Transform playerObjective;
    public Transform npcObjective;
    public float speed;
    public Slider infectionSlider;



    public float detectionRange;
    public bool infectedState;
    public float distanceNPC;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        detectionRange = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        Debug.Log("Infectado " + infectedState);
        if (infectedState)
        {
            Infected();
        }
        else
        {
            Sane();
        }
    }

    void Die()
    {
        if (health <= 0 )
        {
            Destroy(gameObject);
        }
    }

    void Chase()
    {
        if (npcObjective != null)
        {
            float distanceNPC = Vector2.Distance(npcObjective.position, transform.position);
            Debug.Log("Objetivo no nulo");
            if (distanceNPC <= detectionRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, npcObjective.position, speed * Time.deltaTime);
                Debug.Log("persiguiendo objetivo");
            }
        }
        
    }
    //void OnTriggerStay2D(Collider2D col)
    //{
    //   //if (this.infectedState == true)
    //    //{
    //    //    transform.position = Vector2.MoveTowards(transform.position,col.gameObject.transform.position, speed * Time.deltaTime);
    //    //}

    //    string typeTag = col.gameObject.tag;
    //    switch (typeTag)
    //    {
    //        case "NPC":
    //            //transform.position = Vector2.MoveTowards(transform.position, col.gameObject.transform.position, speed * Time.deltaTime);
    //            npcObjective = col.gameObject.transform;
    //            Debug.Log("Hola");
    //            break;
    //        //case "Player":
    //        //    transform.position = Vector2.MoveTowards(transform.position, col.gameObject.transform.position, speed * Time.deltaTime);
    //        //    break;
    //        default:
    //            break;
    //    }
    //}
    void OnTriggerEnter2D(Collider2D col)
    {
        string typeTag = col.gameObject.tag;
        switch (typeTag)
        {
            case "NPC":
                //transform.position = Vector2.MoveTowards(transform.position, col.gameObject.transform.position, speed * Time.deltaTime);
                if (col.gameObject.GetComponent<EnemyLogic>().infectedState)
                {
                    npcObjective = col.gameObject.transform;
                    Debug.Log("Encontro npc");
                    Debug.Log("Infectado :  " + col.gameObject.GetComponent<EnemyLogic>().infectedState);
                }
                break;
            default:
                break;
        }
    }

    void Patrol()
    {

    }

    void Infected()
    {
        Chase();
    }

    void Sane()
    {

    }

    
}
