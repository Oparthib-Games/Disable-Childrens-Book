using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    MainScript mainScript;
    AudioClip tapEntityAudioClip;
    new Camera camera;

    //GameObject TransitionGO;
    public Animator TransitionANIM;

    public string load_scene_command = "NEXT";

    public bool hide_scene_starting_transition = false;

    void Start()
    {
        camera = Camera.main;
        mainScript = FindObjectOfType<MainScript>();
        tapEntityAudioClip = mainScript.tapEntityAudioClip;

        if(hide_scene_starting_transition)
        {
            TransitionANIM.enabled = false;
        }

        //TransitionGO = GameObject.Find("Transition");
        //if (TransitionGO == null)
        //    Debug.LogWarning("TransitionGO NOT FOUND!");
        //else
        //{
        //    TransitionANIM = TransitionGO.GetComponent<Animator>();
        //    TransitionANIM.enabled = false;
        //}
    }

    public void BackToFirstScene()
    {
        SceneHandler.FirstScene();
    }
    public void OnPlayButtonClick()
    {
        load_scene_command = "NEXT";
        TransitionANIM.SetTrigger("TriggerStart");
        TransitionANIM.enabled = true;
        //PlayTapSound();
        //ShowTransition();
        //SceneHandler.NextScene();
    }
    public void OnNextButtonClikc()
    {
        load_scene_command = "NEXT";
        TransitionANIM.SetTrigger("TriggerStart");
        //PlayTapSound();
        //ShowTransition();
        //SceneHandler.NextScene();
    }
    public void OnPrevButtonClikc()
    {
        load_scene_command = "PREV";
        TransitionANIM.SetTrigger("TriggerStart");
        //PlayTapSound();
        //ShowTransition();
        //SceneHandler.PrevScene();
    }
    public void OnReloadButtonClikc()
    {
        load_scene_command = "RELOAD";
        TransitionANIM.SetTrigger("TriggerStart");
        //PlayTapSound();
        //ShowTransition();
        //SceneHandler.ReloadScene();
    }

    public void ChangeScene()
    {
        switch (load_scene_command)
        {
            case "NEXT":
                SceneHandler.NextScene();
                break;
            case "PREV":
                SceneHandler.PrevScene();
                break;
            case "RELOAD":
                SceneHandler.ReloadScene();
                break;
            default:
                SceneHandler.NextScene();
                break;
        }
    }

    //public void ShowTransition()
    //{
    //    if(TransitionANIM != null)
    //    {
    //        TransitionANIM.enabled = true;
    //    } else
    //        Debug.LogWarning("TransitionANIM NOT FOUND!");
    //}
    //public void PlayTapSound()
    //{
    //    AudioSource.PlayClipAtPoint(tapEntityAudioClip, camera.transform.position);
    //}
}
