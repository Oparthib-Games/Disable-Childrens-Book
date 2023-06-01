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

    public float sceneLifespan = 3f; // ! NOT NEEDED
    GameObject canvasContainer; // ! NOT NEEDED
    public bool isQuesType;

    new Camera camera;

    public AudioClip[] clips;

    Animator ANIM;
    AudioSource audioSource;

    public bool isUseSceneDelay = true;
    public bool hasShironam;
    public AudioClip shironamClip;

    [Range(0, 1)] public float shironamVolume = 1;

    void Start()
    {
        ANIM = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (ANIM != null && isUseSceneDelay)
            ANIM.enabled = false;
        if (audioSource != null)
            audioSource.enabled = false;

        camera = Camera.main;
        isPlayingClip = false;

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
        yield return new WaitForSeconds(2);

        if(hasShironam)
        {
            AudioSource.PlayClipAtPoint(shironamClip, camera.transform.position, shironamVolume);
            yield return new WaitForSeconds(shironamClip.length + 1);
        }

        if (ANIM != null)
            ANIM.enabled = true;

        //yield return new WaitForSeconds(sceneLifespan);

        //if(canvasContainer != null)
        //    canvasContainer.SetActive(true);
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
