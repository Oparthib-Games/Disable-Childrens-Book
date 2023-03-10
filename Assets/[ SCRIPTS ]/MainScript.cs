using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public static bool isPlayingAnimation;
    public static bool isPlayingClip;
    public SpriteRenderer[] spriteRenderers;
    public Color textHighlightColor;
    public Entity[] entities;
    public AudioClip tapEntityAudioClip;

    public float sceneLifespan = 3f;
    GameObject canvasContainer;
    public bool isQuesType;

    new Camera camera;

    public AudioClip[] clips;

    void Start()
    {
        camera = Camera.main;
        isPlayingClip = false;
        if(canvasContainer == null)
        {
            Debug.LogWarning("canvasContainer NOT FOUND");
        }
        if(!isQuesType)
        {
            StartCoroutine(CountSceneLifespan());
        }
    }

    void Update()
    {
        
    }

    IEnumerator CountSceneLifespan()
    {
        yield return new WaitForSeconds(sceneLifespan);

        canvasContainer.SetActive(true);
    }

    public void highlightText(int index)
    {
        if(spriteRenderers[index] == null)
        {
            Debug.LogError("Index not found");
        }
        else
        {
            spriteRenderers[index].color = textHighlightColor;
        }
    }

    public void setIsPlayingAnimation(int status)
    {
        isPlayingAnimation = status == 0 ? false : true;

        if(status == 0)
        {
            foreach(SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.black;
            }
        }
    }

    public void startEntityScalling(int index)
    {
        entities[index].setIsStartScaling(true);
    }
    public void stopEntityScalling(int index)
    {
        entities[index].setIsStartScaling(false);
    }

    public void ReloadCurrentScene()
    {

    }

    public void PlayAudioClip(int index)
    {
        AudioSource.PlayClipAtPoint(clips[index], camera.transform.position);
    }
}
