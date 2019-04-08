using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircuitQuestionManager : MonoBehaviour
{
    private CircuitQuestion currentQuestion;
    private List<CircuitQuestion> questionPool;


    //
    public TextMeshProUGUI levelHeader;

    // Start is called before the first frame update
    void Start()
    {
        levelHeader.text = QuestionSceneManager.CURRENT_DIFFICULTY.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateQuestions()
    {

    }

    public void DisplayQuestion()
    {

    }
}
