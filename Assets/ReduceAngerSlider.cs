using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReduceAngerSlider : MonoBehaviour
{
    public Slider slider;
    public float decreaseNumber = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReduceAnger();
    }

    void ReduceAnger()
    {
        if (slider.value > 0)
            slider.value -= decreaseNumber * Time.deltaTime;
    }

    //IEnumerator ReduceAnger()
    //{
    //    if (slider.value > 0)
    //    {
    //        slider.value -= decreaseNumber;
    //    }
    //    yield return new WaitForSeconds(2);

    //}
}
