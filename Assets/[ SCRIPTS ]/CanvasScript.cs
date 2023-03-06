using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    MainScript mainScript;

    void Start()
    {
        mainScript = FindObjectOfType<MainScript>();
    }

    public void OnPlayButtonClick()
    {
        mainScript.LoadNextScene();
    }
}
