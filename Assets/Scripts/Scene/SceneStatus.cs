using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("ChooseMode");
    }

    public void PlaySingle()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void PlayMulti()
    {
        SceneManager.LoadScene("Launcher");
    }

    public void Setting()
    {
        SceneManager.LoadScene("SettingMenu");
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Loading");
    }
}
