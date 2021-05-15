using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        string typeTag = col.gameObject.tag;
        switch (typeTag)
        {
            case "NPC" :
                if(col.gameObject.GetComponent<NpcController2>().states == 0 || 
                   col.gameObject.GetComponent<NpcController2>().states == 2)
                    col.gameObject.GetComponent<NpcController2>().angerSlider.value += 1;
                else if(col.gameObject.GetComponent<NpcController2>().states == 1)
                    col.gameObject.GetComponent<NpcController2>().health -= 1;
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
