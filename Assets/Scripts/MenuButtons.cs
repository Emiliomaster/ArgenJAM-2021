using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public string boliche;

    public void PlayGame()
    {
        SceneManager.LoadScene(boliche);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
