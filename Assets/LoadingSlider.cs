using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        slider.maxValue = 10;
    }
    private void Update()
    {
        if(slider.value <= slider.maxValue)
        slider.value += Time.deltaTime;
    }
}
