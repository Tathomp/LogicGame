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

    public GameObject questionSelected;

	// Use this for initialization
	void Start () {

        currSelection = 0;

        GenerateTestQuestion();

        DisplayQuestion();

	}
	
	// Update is called once per frame
	void Update () {

    
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            currSelection--;

            if(currSelection == -1)
            {
                currSelection = 3;
            }

            questionSelected.transform.SetParent(Blanks[currSelection].transform);
            questionSelected.transform.position = new Vector3(questionSelected.transform.position.x, Blanks[currSelection].transform.position.y, 0);


        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            currSelection++;

            if(currSelection == 4)
            {
                currSelection = 0;
            }

            questionSelected.transform.SetParent(Blanks[currSelection].transform);
            questionSelected.transform.position = new Vector3(questionSelected.transform.position.x, Blanks[currSelection].transform.position.y, 0);
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            //selectAnswer = true;

            if(resultsHeader.text != "")
            {
                SceneManager.LoadScene("CiruitQuestion");
            }

            if( CheckForCorrectness())
            {
                resultsHeader.text = ("All answers are correct!");
            }
            else
            {
                resultsHeader.text = ("Some answers are wrong");
            }

        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("User selected answer 1");
            userAnswer[currSelection] = 1;
            Blanks[currSelection].text = Answers[0].text;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("User selected answer 2");
            userAnswer[currSelection] = 2;
            Blanks[currSelection].text = Answers[1].text;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("User selected answer 3");
                userAnswer[currSelection] = 3;
            Blanks[currSelection].text = Answers[2].text;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.X))
        {
                Debug.Log("User selected answer 4");
                userAnswer[currSelection] = 4;
                Blanks[currSelection].text = Answers[3].text;
        }

        Debug.Log(currSelection);

    }

    public void GenerateTestQuestion()
    {
        currQuestion = new MultipleChoiceQuestion();

        currQuestion.choices.Add(new Choice("Cats", "meow"));
        currQuestion.choices.Add(new Choice("Dogs", "bark"));
        currQuestion.choices.Add(new Choice("Cows", "moo"));
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
                return false;
            }
        }

        return true;
    }
}
