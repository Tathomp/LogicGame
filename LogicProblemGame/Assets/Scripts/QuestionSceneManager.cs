using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionSceneManager : MonoBehaviour {

    public static DifficultySelectEnum CURRENT_DIFFICULTY;

    public TextMeshProUGUI label;


    Queue<Question> questionPool;

	// Use this for initialization
	void Start () {
        InitLevelHeader();
	}

    private void InitLevelHeader()
    {
        label.text = "Level: " + CURRENT_DIFFICULTY + "\nQuestion Number: " + 1;
    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("User selected answer A");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("User selected answer B");
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

    }

    public void NextQuestion()
    {

    }
}

