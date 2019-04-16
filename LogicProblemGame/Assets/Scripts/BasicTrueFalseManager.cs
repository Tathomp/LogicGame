using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class BasicTrueFalseManager : MonoBehaviour
{
    public static DifficultySelectEnum CURRENT_DIFFICULTY;

    public TextMeshProUGUI label;
    public TextMeshProUGUI question;
    public TextMeshProUGUI correctLabel;

    Queue<Question> questionPool;
    Question currQuestion;

    int curr_score, questionsRight, questionsWrong, questionThreshold = 2;
    bool goToNextQuestion = false;

    // Use this for initialization
    void Start()
    {
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
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("User selected answer A");
            CheckAnswer(true);
        }
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("User selected answer B");
            CheckAnswer(false);
        }
        else if (goToNextQuestion && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7)))
        {
            SceneManager.LoadScene("QuestionScene");
        }
        else if (goToNextQuestion == false && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7)))
        {
            SceneManager.LoadScene("BasicTrueFalse");

        }

    }

    private void GenerateQuestions()
    {
        Question q = new Question("The earth is round", true);
        questionPool.Enqueue(q);

        q = new Question("Zombies are real", false);
        questionPool.Enqueue(q);

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
            if (questionsRight >= questionThreshold)
            {
                goToNextQuestion = true;
                DifficultySelectManager.CURRENT_SCORE += curr_score;
                correctLabel.text = questionsRight + " questions right out of " + (questionsRight + questionsWrong) + "\nPoints Earned: " + curr_score + "\nTotal Points: " + DifficultySelectManager.CURRENT_SCORE;
            }
            else
            {
                correctLabel.text = questionsRight + " question right. Not enough points to continue, please retake test.";
                curr_score = 0;
                goToNextQuestion = false;
            }
        }
    }

    public void CheckAnswer(bool i)
    {
        if (currQuestion.answer == i)
        {
            correctLabel.text = ("Correct Answer");
            questionsRight++;
            curr_score += 5;
        }
        else
        {
            correctLabel.text = ("Answer Wrong");
            questionsWrong--;
        }

        NextQuestion();
    }

    public void PrintQuestion()
    {
        question.text = currQuestion.question;
    }
}
