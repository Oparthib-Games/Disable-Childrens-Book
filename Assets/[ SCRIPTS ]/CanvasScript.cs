using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    //MainScript mainScript;

    void Start()
    {
        //mainScript = FindObjectOfType<MainScript>();
    }

    public void OnPlayButtonClick()
    {
        SceneHandler.NextScene();
    }

    public void OnNextButtonClikc()
    {
        SceneHandler.NextScene();
    }
    public void OnPrevButtonClikc()
    {
        SceneHandler.PrevScene();
    }
    public void OnReloadButtonClikc()
    {
        SceneHandler.ReloadScene();
    }
}
