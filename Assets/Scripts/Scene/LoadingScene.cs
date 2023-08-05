using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private float timeLoad = 5.0f;
    private Slider slider;
    [SerializeField]
    private GameObject LoadingBar;
    private void Start()
    {
        slider = LoadingBar.GetComponent<Slider>();
        slider.value = 0;
    }

    private void Update()
    {
        if (slider.value < timeLoad)
        {
            slider.value = Time.time;
        }
        else 
        {
            SceneManager.LoadScene("Menu");
        }

    }
}
