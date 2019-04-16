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
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("User selected answer A");
            CheckAnswer(true);
        }
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("User selected answer B");
            CheckAnswer(false);
        }
        else if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && goToNextQuestion)
        {
            SceneManager.LoadScene("ALUQuestion");

        }
        else if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && goToNextQuestion == false)
        {
            SceneManager.LoadScene("CircuitQuestion");

        }
    }

    public void GenerateQuestions()
    {
        questionPool = new Queue<CircuitQuestion>();

        CircuitQuestion q = new CircuitQuestion("logicgateOr", "If input A is 1 and input B is 0, what is output q?", true);
        questionPool.Enqueue(q);

        q = new CircuitQuestion("logicgateNot", "If input A is 1, what is output X?", false);
        questionPool.Enqueue(q);

        q = new CircuitQuestion("logicgateAnd", "If input A is 0 and input B is 1, what is output X?", false);
        questionPool.Enqueue(q);

        q = new CircuitQuestion("logicgateNand", "If input A is 0 and input B is 0, what is output Q?", true);
        questionPool.Enqueue(q);

        q = new CircuitQuestion("logicgateNot", "If output X is 1, what is input A?", false);
        questionPool.Enqueue(q);


        q = new CircuitQuestion("logicgateNor", "If input A is 0 and input B is 0, what is output Q?", true);
        questionPool.Enqueue(q);

        q = new CircuitQuestion("logicgateAnd", "If input A is 1 and input B is 1, what is output X?", true);
        questionPool.Enqueue(q);

        q = new CircuitQuestion("logicgateNand", "If input A is 1 and output Q is 0, what is input B?", true);
        questionPool.Enqueue(q);

        NextQuestion();
    }



    public void CheckAnswer(bool i)
    {
        if (currQuestion.answer == i)
        {
            correctLabel.text = ("Correct Answer");
            curr_score +=20;
            questionsRight++;
        }
        else
        {
            correctLabel.text = ("Answer Wrong");
            questionsWrong++;
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

            if(questionsRight >= questionThreshold)
            {
                goToNextQuestion = true;
                DifficultySelectManager.CURRENT_SCORE += curr_score;
                correctLabel.text = questionsRight + " questions right out of " + (questionsRight + questionsWrong) + "\nPoints Earned: " + curr_score + "\nTotal Points: " + DifficultySelectManager.CURRENT_SCORE;
            }
            else
            {
                goToNextQuestion = false;
                correctLabel.text = questionsRight + " question right. Not enough points to continue, please retake test.";
                curr_score = 0;
            }
        }
    }
}
