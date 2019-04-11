using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CircuitQuestionManager : MonoBehaviour
{
    private CircuitQuestion currQuestion;
    private Queue<CircuitQuestion> questionPool;

    public TextMeshProUGUI correctLabel;
    public TextMeshProUGUI question;
    public Image circuitImage;

    //
    public TextMeshProUGUI levelHeader;

    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestions();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("User selected answer A");
            CheckAnswer(true);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("User selected answer B");
            CheckAnswer(false);
        }
        else if(Input.GetKeyDown(KeyCode.Return) && correctLabel.text != "")
        {
            SceneManager.LoadScene("ALUQuestion");

        }
    }

    public void GenerateQuestions()
    {
        questionPool = new Queue<CircuitQuestion>();

        CircuitQuestion q = new CircuitQuestion("logicgateOr", "If input A is 1 and input B is 0, what is output q?", false);
        questionPool.Enqueue(q);

        q = new CircuitQuestion("andgate", "If input A is 0 and input B is 0, what is output Q?", true);
        questionPool.Enqueue(q);

        NextQuestion();
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
        circuitImage.sprite = Resources.Load<Sprite>(currQuestion.filepath);
    }

    public void NextQuestion()
    {
        if (questionPool.Count >= 1)
        {
            currQuestion = questionPool.Dequeue();
            PrintQuestion();
        }
        else
        {
        }
    }
}
