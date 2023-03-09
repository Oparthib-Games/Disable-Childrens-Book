using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public AudioClip myClip;
    public float clipLength;
    new Camera camera;
    SpriteRenderer spriteRenderer;
    public Color tapColor;

    void Start()
    {
        camera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        clipLength = myClip.length;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (MainScript.isPlayingAnimation)
        {
            Debug.LogError("Still playing animation.");
        }
        else if(MainScript.isPlayingClip)
        {
            Debug.LogError("Still playing my clip.");
        }
        else
        {
            StartCoroutine(HighlightOnTap());
        }
    }

    IEnumerator HighlightOnTap()
    {
        PlayTextClip();
        MainScript.isPlayingClip = true;

        Color old_color = Color.black;

        if (spriteRenderer != null)
        {
            old_color = spriteRenderer.color;

            spriteRenderer.color = tapColor;
        }

        yield return new WaitForSeconds(clipLength);

        if (spriteRenderer != null)
        {
            spriteRenderer.color = old_color;
        }

        MainScript.isPlayingClip = false;
    }

    public void PlayTextClip()
    {
        AudioSource.PlayClipAtPoint(myClip, camera.transform.position);
    }
}
