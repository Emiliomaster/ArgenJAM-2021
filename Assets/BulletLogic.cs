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
                col.gameObject.GetComponent<NPCLogic>().angerSlider.value += 1;
                break;
            case "Enemy":
                    col.gameObject.GetComponent<EnemyLogic>().health -= 1;
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
