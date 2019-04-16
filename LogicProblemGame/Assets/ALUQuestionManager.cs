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


    int curr_score, questionsRight, questionsWrong, questionThreshold = 2;
    bool goToNextQuestion = false, redoQuestion = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestions();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            CheckAnswer("and");
        }
        else if(Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            CheckAnswer("or");
        }
        else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            CheckAnswer("add");
        }
        else if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            CheckAnswer("subtract");
        }
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            CheckAnswer("slt");
        }
        else if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            CheckAnswer("nor");
        }
        else if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && goToNextQuestion)
        {
            SceneManager.LoadScene("DifficultySelect");

        }
        else if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && redoQuestion)
        {
            SceneManager.LoadScene("ALUQuestion");

        }
    }

    private void GenerateQuestions()
    {
        questionPool = new Queue<ALUQuestion>();

        ALUQuestion q = new ALUQuestion("0", "0", "00", "and");
        questionPool.Enqueue(q);

        q = new ALUQuestion("0", "1", "10", "subtract");
        questionPool.Enqueue(q);


        q = new ALUQuestion("0", "0", "01", "or");
        questionPool.Enqueue(q);


        q = new ALUQuestion("1", "1", "00", "nor");
        questionPool.Enqueue(q);


        q = new ALUQuestion("0", "0", "10", "add");
        questionPool.Enqueue(q);


        q = new ALUQuestion("0", "1", "11", "slt");
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
            if (questionsRight >= questionThreshold)
            {
                goToNextQuestion = true;
                DifficultySelectManager.CURRENT_SCORE += curr_score;
                correctLabel.text = questionsRight + " questions right out " + (questionsRight + questionsWrong) + "\nPoints Earned: " + curr_score + "\nTotal Points: " + DifficultySelectManager.CURRENT_SCORE;
            }
            else
            {
                redoQuestion = true;
                correctLabel.text = questionsRight + ". Not enough points to continue, please retake test.";
                curr_score = 0;
            }
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
            curr_score += 25;
            questionsRight++;
        }
        else
        {
            correctLabel.text = ("Wrong");
            questionsWrong++;
        }

        NextQuestion();
    }

}
