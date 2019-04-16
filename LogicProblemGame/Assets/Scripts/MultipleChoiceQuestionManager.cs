using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultipleChoiceQuestionManager : MonoBehaviour {

    // editor
    public TextMeshProUGUI[] Questions, Blanks, Answers;
    public TextMeshProUGUI resultsHeader;

    public MultipleChoiceQuestion currQuestion;

    int[] userAnswer, correctAnswers;


    //user input
    int currSelection;
    bool selectAnswer;
    bool axisInUSe = false;

    int curr_score, questionsRight, questionsWrong, questionThreshold = 2;
    bool goToNextQuestion = false, redoQuestion = false;

    public GameObject questionSelected;

	// Use this for initialization
	void Start () {

        currSelection = 0;
        curr_score = 0;

        GenerateTestQuestion();

        DisplayQuestion();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            axisInUSe = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxisRaw("Vertical") == 1)
        {
            if(axisInUSe == false)
            {
                axisInUSe = true;

                currSelection--;

                if (currSelection == -1)
                {
                    currSelection = 4;
                }

                questionSelected.transform.SetParent(Blanks[currSelection].transform);
                questionSelected.transform.position = new Vector3(questionSelected.transform.position.x, Blanks[currSelection].transform.position.y, 0);

            }



        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") <= -0.9f)
        {
            if(axisInUSe == false)
            {
                axisInUSe = true;

                currSelection++;

                if (currSelection == 5)
                {
                    currSelection = 0;
                }

                questionSelected.transform.SetParent(Blanks[currSelection].transform);
                questionSelected.transform.position = new Vector3(questionSelected.transform.position.x, Blanks[currSelection].transform.position.y, 0);

            }
        }
        else if(Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            //selectAnswer = true;
            CheckForCorrectness();

            if(redoQuestion)
            {
                SceneManager.LoadScene("MultipleChoiceScene");
                return;
            }

            if(goToNextQuestion)
            {
                SceneManager.LoadScene("CiruitQuestion");
                return;
            }


            if(questionsRight >= questionThreshold && !redoQuestion && !goToNextQuestion)
            {
                DifficultySelectManager.CURRENT_SCORE += curr_score;
          
                resultsHeader.text = questionsRight + " questions right out of " + (questionsRight + questionsWrong) + "\nPoints Earned: " + curr_score + "\nTotal Points: " + DifficultySelectManager.CURRENT_SCORE;
                goToNextQuestion = true;
            }
            else
            {
                resultsHeader.text = questionsRight + " question right. Not enough points to continue, please retake test.";
                curr_score = 0;
                redoQuestion = true;
            }

        }

        else if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("User selected answer 1");
            userAnswer[currSelection] = 1;
            Blanks[currSelection].text = Answers[0].text;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("User selected answer 2");
            userAnswer[currSelection] = 2;
            Blanks[currSelection].text = Answers[1].text;

        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("User selected answer 3");
                userAnswer[currSelection] = 3;
            Blanks[currSelection].text = Answers[2].text;

        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("User selected answer 4");
            userAnswer[currSelection] = 4;
            Blanks[currSelection].text = Answers[3].text;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("User selected answer 5");
            userAnswer[currSelection] = 5;
            Blanks[currSelection].text = Answers[4].text;
        }

    }

    public void GenerateTestQuestion()
    {
        currQuestion = new MultipleChoiceQuestion();

        currQuestion.choices.Add(new Choice("Double Negation", "~(~p)"));
        currQuestion.choices.Add(new Choice("Identiy Law","p v ~ t == p"));
        currQuestion.choices.Add(new Choice("De Morgan's Law", "~(p ^ q) == ~p v ~q"));
        currQuestion.choices.Add(new Choice("Commtative law", "p ^ q == q ^ p"));
        currQuestion.choices.Add(new Choice("Distribution law", "x ^ (y v z) == (x ^ y) v (x ^ z)"));
    }

    public void DisplayQuestion()
    {
        int questionCount = currQuestion.choices.Count;
        int currQuestionNumber = 1;

        userAnswer = new int[questionCount];
        correctAnswers = new int[questionCount];

        List<int> randomPool = new List<int>();


        for (int i = 0; i < correctAnswers.Length; i++)
        {
            correctAnswers[i] = -1;
            randomPool.Add(i);
        }




        foreach (Choice choice in currQuestion.choices)
        {
            //print the question before the blank
            Questions[currQuestionNumber - 1].text = choice.Question;
            //assign the answer to the answer array

            int rng = Random.Range(0, randomPool.Count - 1);
            int i = randomPool[rng];
            randomPool.RemoveAt(rng);
            Debug.Log(rng);



            Answers[i].text = choice.Answer;

            correctAnswers[currQuestionNumber - 1] = i;
            //place that index in the corrent answer array

            //
            currQuestionNumber++;
        }

    }

    public bool CheckForCorrectness()
    {


        for (int i = 0; i < userAnswer.Length; i++)
        {
            if(userAnswer[i] != correctAnswers[i] + 1)
            {
                questionsWrong++;
            }
            else
            {
                questionsRight++;
                curr_score += 15;
            }

        }

        if(questionsWrong > 0)
        {
            return false;
        }

        return true;
    }
}
