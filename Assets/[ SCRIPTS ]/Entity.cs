using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool isStartScaling;
    public float scaleAddition = 2;
    public float scaleMultiplier = 3;
    public float timeMultiplier = 2;

    void Start()
    {
        
    }

    void Update()
    {
        if(isStartScaling)
        {
            //float time = Time.time * timeMultiplier;
            //float math = Mathf.Sin(time) / scaleMultiplier;

            //Vector3 vec = new Vector3(1, 1, 1) * (math + scaleAddition);

            //transform.localScale = vec;
        }
    }

    public void setIsStartScaling(bool status)
    {
        isStartScaling = status;
    }
}
