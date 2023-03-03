using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH_0 : MonoBehaviour
{
    public AudioClip smallPop;
    public AudioClip bigPop;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SmallPop()
    {
        AudioSource.PlayClipAtPoint(smallPop, Camera.main.transform.position);
    }

    public void BigPop()
    {
        AudioSource.PlayClipAtPoint(bigPop, Camera.main.transform.position);
    }
}
