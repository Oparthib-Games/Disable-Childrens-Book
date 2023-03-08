using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool isStartScaling;
    public float scaleAddition = 2;
    public float scaleMultiplier = 3;
    public float timeMultiplier = 2;
    public bool isQuesType;

    Animator ANIM;

    

    void Awake()
    {
        ANIM = GetComponent<Animator>();
        if(ANIM != null)
        {
            ANIM.enabled = false;
            //this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(isStartScaling)
        {
            if(ANIM != null)
            {
                ANIM.enabled = true;
            }

            //float time = Time.time * timeMultiplier;
            //float math = Mathf.Sin(time) / scaleMultiplier;

            //Vector3 vec = new Vector3(1, 1, 1) * (math + scaleAddition);

            //transform.localScale = vec;
        }
        else
        {
            if (ANIM != null)
            {
                ANIM.enabled = false;
            }
        }
    }

    public void setIsStartScaling(bool status)
    {
        isStartScaling = status;

        if(status == true)
        {
            this.gameObject.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if(isQuesType)
        {
            Question question = this.transform.parent.GetComponent<Question>();

            if(question != null)
            {
                question.Answering(this);
            } 
            else
            {
                Debug.LogError("Something is terribly wrong!!");
            }
        }
    }
}
