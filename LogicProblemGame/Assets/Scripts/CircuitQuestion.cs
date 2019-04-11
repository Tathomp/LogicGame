using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitQuestion 
{
    public string filepath;
    public string question;
    public bool answer;

    public CircuitQuestion(string fp, string question, bool answer)
    {
        this.filepath = fp;
        this.answer = answer;
        this.question = question;
    }

}
