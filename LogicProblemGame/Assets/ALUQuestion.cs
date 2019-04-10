using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALUQuestion
{
    private string inputA, inputB, inputAlu;
    public string answer;
    
    public ALUQuestion(string a, string b, string alu, string answer)
    {

        inputA = a;
        inputB = b;
        inputAlu = alu;

        this.answer = answer;
    }

    public string GetQuestion()
    {
        return "If the input of A is " + inputA + ", B is " + inputB + " and the ALU control is " + inputAlu +
            ", what function is called?";
    }
}
