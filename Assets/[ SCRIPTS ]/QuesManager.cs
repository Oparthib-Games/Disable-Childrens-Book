using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesManager : MonoBehaviour
{
    public int currQuesIndex = 0;
    public Question[] questions;

    public GameObject rightAnswerGO;
    public GameObject wrongAnswerGO;

    public static bool canAnswer;

    AudioClip tapEntityAudioClip;
    new Camera camera;

    MainScript mainScript;

    public AudioClip rightAnswerClip;
    public AudioClip wrongAnswerClip;

    void Start()
    {
        camera = Camera.main;
        mainScript = GetComponent<MainScript>();
        tapEntityAudioClip = mainScript.tapEntityAudioClip;

        if (tapEntityAudioClip == null)
        {
            Debug.LogError("tapEntityAudioClip not set!!");
        }
    }

    void Update()
    {

    }

    public void AnswerTrigger(bool isCorrent)
    {
        if(canAnswer)
        {
            StartCoroutine(AnswerTriggerIE(isCorrent));
        } else
        {
            Debug.LogError("Can't Answer Now.");
        }
    }

    IEnumerator AnswerTriggerIE(bool isCorrent)
    {
        AudioSource.PlayClipAtPoint(tapEntityAudioClip, camera.transform.position);

        canAnswer = false;
        if (isCorrent)
        {
            rightAnswerGO.SetActive(true);
        }
        else
        {
            wrongAnswerGO.SetActive(true);
        }

        yield return new WaitForSeconds(3f);

        if(!isCorrent)
        {
            canAnswer = true;
        }
        else
        {
            ShowNextQuestion();
        }

        rightAnswerGO.SetActive(false);
        wrongAnswerGO.SetActive(false);
    }

    public void ShowNextQuestion()
    {
        questions[currQuesIndex].gameObject.SetActive(false);
        currQuesIndex++;
        if (questions.Length > currQuesIndex)
        {
            questions[currQuesIndex].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("There are not further question.");
            SceneHandler.NextScene();
        }
    }
}
