using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ALUQuestionManager : MonoBehaviour
{
    public TextMeshProUGUI question, resultsLabel;

    private ALUQuestion currQuestion;
    private Queue<ALUQuestion> questionPool;


    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestions();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            CheckAnswer("and");
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            CheckAnswer("or");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            CheckAnswer("add");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            CheckAnswer("subtract");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            CheckAnswer("slt");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            CheckAnswer("nor");
        }
    }

    private void GenerateQuestions()
    {
        questionPool = new Queue<ALUQuestion>();

        ALUQuestion q = new ALUQuestion("0", "0", "00", "and");
        questionPool.Enqueue(q);

        q = new ALUQuestion("0", "1", "10", "subtract");
        questionPool.Enqueue(q);

        NextQuestion();
    }

    private void NextQuestion()
    {
        if(questionPool.Count > 0)
        {
            currQuestion = questionPool.Dequeue();
            PrintQuesiton();
        }
        else
        {
            resultsLabel.text = ("Game Oover");
            SceneManager.LoadScene("DifficultySelect");
        }
    }

    private void PrintQuesiton()
    {
        question.text = currQuestion.GetQuestion();
    }

    public void CheckAnswer(string userAnser)
    {
        if(userAnser == currQuestion.answer)
        {
            resultsLabel.text = ("Correct");
        }
        else
        {
            resultsLabel.text = ("Wrong");
        }

        NextQuestion();
    }

}
