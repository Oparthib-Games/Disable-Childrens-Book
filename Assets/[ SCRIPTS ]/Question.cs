using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public string question = "";
    public Entity[] entities;
    public int answerIndex;
    public SpriteRenderer[] spriteRenderers;
    public Color textHighlightColor;

    QuesManager quesManager;

    new Camera camera;

    void Start()
    {
        camera = Camera.main;
        quesManager = FindObjectOfType<QuesManager>();
        QuesManager.canAnswer = true;
    }

    void Update()
    {
        
    }

    public void highlightText(int index)
    {
        if (spriteRenderers[index] == null)
        {
            Debug.LogError("Index not found");
        }
        else
        {
            spriteRenderers[index].color = textHighlightColor;
        }
    }

    public void Answering(Entity p_entity)
    {
        Debug.Log("Answered.");
        int i = 0;
        foreach (Entity entity in entities)
        {
            if(entity == p_entity)
            {
                if(i == answerIndex)
                {
                    Debug.Log("Corrent Answer");
                    quesManager.AnswerTrigger(true);
                    AudioSource.PlayClipAtPoint(quesManager.rightAnswerClip, camera.transform.position);
                }
                else
                {
                    Debug.Log("Wrong Answer");
                    quesManager.AnswerTrigger(false);
                    AudioSource.PlayClipAtPoint(quesManager.wrongAnswerClip, camera.transform.position);
                }
            }
            i++;
        }
    }
}
