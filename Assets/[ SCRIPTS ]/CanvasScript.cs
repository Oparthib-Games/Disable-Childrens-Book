using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    MainScript mainScript;
    AudioClip tapEntityAudioClip;
    new Camera camera;

    void Start()
    {
        camera = Camera.main;
        mainScript = FindObjectOfType<MainScript>();
        tapEntityAudioClip = mainScript.tapEntityAudioClip;
    }

    public void OnPlayButtonClick()
    {
        //PlayTapSound();
        SceneHandler.NextScene();
    }

    public void OnNextButtonClikc()
    {
        //PlayTapSound();
        SceneHandler.NextScene();
    }
    public void OnPrevButtonClikc()
    {
        //PlayTapSound();
        SceneHandler.PrevScene();
    }
    public void OnReloadButtonClikc()
    {
        //PlayTapSound();
        SceneHandler.ReloadScene();
    }

    public void PlayTapSound()
    {
        AudioSource.PlayClipAtPoint(tapEntityAudioClip, camera.transform.position);
    }
}
