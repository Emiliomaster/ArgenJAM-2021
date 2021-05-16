using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletLogic : MonoBehaviour
{
    Color colorRed = new Color(1, 0, 0);
    Color colorBlue = new Color(0, 0, 1);

    private void OnCollisionEnter2D(Collision2D col)
    {
        string typeTag = col.gameObject.tag;
        switch (typeTag)
        {
            case "NPC" :
                if (col.gameObject.GetComponent<NpcController2>().states == 0 ||
                    col.gameObject.GetComponent<NpcController2>().states == 2)
                {
                    col.gameObject.GetComponent<NpcController2>().angerSlider.value += 1;
                    col.gameObject.GetComponent<SpriteRenderer>().color = colorRed;
                }
                else if (col.gameObject.GetComponent<NpcController2>().states == 1)
                {
                    col.gameObject.GetComponent<NpcController2>().health -= 1;
                    col.gameObject.GetComponent<SpriteRenderer>().color = colorBlue;
                }
                break;
            case "PatientZ":
                col.gameObject.GetComponent<PatientZeroController>().health -= 1;
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
