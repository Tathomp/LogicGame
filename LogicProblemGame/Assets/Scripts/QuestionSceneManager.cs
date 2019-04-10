using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionSceneManager : MonoBehaviour {

    public static DifficultySelectEnum CURRENT_DIFFICULTY;

    public TextMeshProUGUI label;
    public TextMeshProUGUI question;
    public TextMeshProUGUI correctLabel;

    Queue<Question> questionPool;
    Question currQuestion;

	// Use this for initialization
	void Start () {
        questionPool = new Queue<Question>();

        InitLevelHeader();
	}

    private void InitLevelHeader()
    {
        label.text = "Level: " + CURRENT_DIFFICULTY + "\nQuestion Number: " + 1;

        GenerateQuestions();
        currQuestion = questionPool.Dequeue();
        PrintQuestion();
    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("User selected answer A");
            CheckAnswer(true);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("User selected answer B");
            CheckAnswer(false);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("User selected answer C");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("User selected answer D");
        }

    }

    private void GenerateQuestions()
    {
        Question q = new Question("T ^ F = _", false);
        questionPool.Enqueue(q);

        q = new Question("T v F = _", true);
        questionPool.Enqueue(q);

        q = new Question("T ^ F = _", false);
        questionPool.Enqueue(q);

    }

    public void NextQuestion()
    {
        if(questionPool.Count >= 1)
        {
            currQuestion = questionPool.Dequeue();
            PrintQuestion();
        }
        else
        {
            SceneManager.LoadScene("MultipleChoiceScene");
        }
    }

    public void CheckAnswer(bool i)
    {
        if (currQuestion.answer == i)
        {
            correctLabel.text = ("Correct Answer");
        }
        else
        {
            correctLabel.text = ("Answer Wrong");
        }

        NextQuestion();
    }

    public void PrintQuestion()
    {
        question.text = currQuestion.question;
    }
}

