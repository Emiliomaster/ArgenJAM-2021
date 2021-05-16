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

    public int health = 3;
    void Start()
    {
        healthSlider.value = health;
    }
    // Update is called once per frame
    void Update()
    {
        CheckDefeatState();
    }

    void CheckDefeatState()
    {
        if (infectionSlider.value >= infectionSlider.maxValue || angerSlider.value >= angerSlider.maxValue -0.1f || healthSlider.value <= 0)
        {
            panel.SetActive(true);
            defeatMenu.SetActive(true);
            Time.timeScale = 0;
           
        }
    }
}
