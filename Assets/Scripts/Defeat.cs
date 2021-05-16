using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Defeat : MonoBehaviour
{
    public Slider angerSlider;
    public Slider infectionSlider;
    public Slider healthSlider;
    public GameObject panel;
    public GameObject defeatMenu;

    public Image borderDamage;
    public int health = 3;

    float timeBorderAlph;
    void Start()
    {
        timeBorderAlph = 0.25f;
        //healthSlider.value = health;
    }
    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        CheckDefeatState();
        checkHealth();
        //DamageBorder();
    }

    void CheckDefeatState()
    {
        if (infectionSlider.value >= infectionSlider.maxValue || angerSlider.value >= angerSlider.maxValue - 0.1f  || healthSlider.value <= 0 )
        {
            panel.SetActive(true);
            defeatMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void DamageBorder()
    {
        if (borderDamage.color == new Color(255, 255, 255, 255))
        {
            Debug.Log("Daño");
            if (timeBorderAlph <= 0)
            {
                borderDamage.color = new Color(255, 255, 255, 0);
                timeBorderAlph = 0.25f;
            }
            else
                timeBorderAlph -= Time.deltaTime;
        }
    }

    void checkHealth()
    {
        switch (health)
        {
            case 1:
                borderDamage.color += new Color(255, 255, 255, 255);
                break;
            case 2:
                borderDamage.color += new Color(155, 155, 155, 50);
                break;
            case 3:
                borderDamage.color += new Color(255, 255, 255, 0);
                break;
        }
    }

}
