using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public int health;
    public float speedInfected;
    public float speedPatrol;
    public int infectedState;
    public float detectionRange;

    public float infectionRange;
    
    public Transform playerObjective;
    public Transform npcObjective;

    float distanceNPC;
    float distancePlayer;

    NpcController npcSpt;
    bool patrolOff;

    Vector3 path = new Vector3 (.5f,0.5f,.5f);


    //patrulla
    public Vector2 decisionTime = new Vector2(1, 4);
    float decisionTimeCount = 0;
    Vector3[] moveDirections = new Vector3[] {Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.zero, Vector3.zero};
    int currentMoveDirection;


    void Start()
    {
        health = 2;
        playerObjective = GameObject.FindGameObjectWithTag("Player").transform;

        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        ChooseMoveDirection();

    }

    void FixedUpdate()
    {
        NpcStates();
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    string typeTag = col.gameObject.tag;
    //    GameObject anyActor = col.gameObject;
    //    switch (typeTag)
    //    {
    //        case "NPC":
    //            npcSpt = anyActor.GetComponent<NpcController>();
    //            if (npcSpt.infectedState == 0) //NPC Sano
    //            {
    //                npcObjective = anyActor.gameObject.transform;
    //                distanceNPC = Vector2.Distance(npcObjective.position, transform.position);
    //                patrolOff = true;
    //                Debug.Log("Detecto npc");
    //            }

    //            break;
    //        default:
    //            break;
    //    }
    //}

    private void OnTriggerStay2D(Collider2D col)
    {
        string typeTag = col.gameObject.tag;
        GameObject anyActor = col.gameObject;
        switch (typeTag)
        {
            case "NPC":
                NpcController npcSpt = anyActor.GetComponent<NpcController>();
                if (npcSpt.infectedState == 0) //NPC Sano
                {
                    npcObjective = anyActor.gameObject.transform;
                    distanceNPC = Vector2.Distance(npcObjective.position, transform.position);
                    patrolOff = true;
                    Debug.Log("Detecto npc");
                }
                break;
            default:
                break;
        }
    }


    void NpcStates()
    {
        switch (infectedState)
        {
            case 0://Sano
                NpcPatrol();
                break;
            case 1: //Infectado
                if (patrolOff)
                    Chase();
                else
                    NpcPatrol();

                break;
            case 2: //Inmunizado
                NpcPatrol();
                break;
            default:
                break;

        }
    }


    void NpcPatrol()
    {
        transform.position += moveDirections[currentMoveDirection] * Time.deltaTime * speedPatrol;
        if (decisionTimeCount > 0) 
            decisionTimeCount -= Time.deltaTime;
        else
        {
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
            ChooseMoveDirection();
        }
    }

    void ChooseMoveDirection()
    {
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }

    void Chase()
    {
        distancePlayer = Vector2.Distance(playerObjective.position, transform.position);
        Debug.Log("Objetivo no nulo");

        if (distancePlayer <= detectionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerObjective.position, speedInfected * Time.deltaTime);

            Vector2 directionLook = new Vector2(playerObjective.position.x - transform.position.x,
                                                playerObjective.position.y - transform.position.y);
            transform.up = directionLook;
            Debug.Log("persiguiendo player");
        }
        else if (distanceNPC <= detectionRange && npcObjective != null && npcObjective.GetComponent<NpcController>().infectedState == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, (npcObjective.position + path), speedInfected * Time.deltaTime);

            Vector2 directionLook = new Vector2(npcObjective.position.x - transform.position.x, 
                                                npcObjective.position.y - transform.position.y);
            transform.up = directionLook;
            Debug.Log("persiguiendo npc");
        }
    }


}
