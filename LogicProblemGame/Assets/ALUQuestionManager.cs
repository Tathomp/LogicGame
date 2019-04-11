using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ALUQuestionManager : MonoBehaviour
{
    public TextMeshProUGUI question, correctLabel;

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
        else if (Input.GetKeyDown(KeyCode.Return) && correctLabel.text != "")
        {
            SceneManager.LoadScene("DifficultySelect");

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
            correctLabel.text = ("Game Oover");
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
            correctLabel.text = ("Correct");
        }
        else
        {
            correctLabel.text = ("Wrong");
        }

        NextQuestion();
    }

}
