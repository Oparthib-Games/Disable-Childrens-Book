using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public CanvasScript canvasScript;

    public void StarAnimationEndEvent()
    {
        canvasScript.ChangeScene();
    }
}
