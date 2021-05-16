using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    public GameObject patientZeroRef;
    Transform pZeroTrans;
    float distancePZ;
    public GameObject signal;
    

    void Start()
    {
        patientZeroRef = GameObject.FindGameObjectWithTag("PatientZ");
        pZeroTrans = patientZeroRef.transform;
    }

    void FixedUpdate()
    {
        Movement();
        DetectedPZ();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        }
    }

    void DetectedPZ()
    {
        distancePZ = Vector2.Distance(pZeroTrans.position, transform.position);
        if (distancePZ <= 2.5f)
        {
            signal.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
        else
            signal.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

    }
}
