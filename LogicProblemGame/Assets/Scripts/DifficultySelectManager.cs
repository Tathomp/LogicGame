using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelectManager : MonoBehaviour {

    public DifficultySelectButton firstButton;
    public BackgroundPrefabManager background;

    public static int CURRENT_SCORE;


    private bool axisInUse = false;

    private KeyCode[] keycodes = new KeyCode[] {
        KeyCode.JoystickButton0,
        KeyCode.JoystickButton1,
        KeyCode.JoystickButton2,
        KeyCode.JoystickButton3,
        KeyCode.JoystickButton4,
        KeyCode.JoystickButton5,
        KeyCode.JoystickButton6,
        KeyCode.JoystickButton7,
        KeyCode.JoystickButton8,
        KeyCode.JoystickButton9,
        KeyCode.JoystickButton10,
        KeyCode.JoystickButton11,
        KeyCode.JoystickButton12,
        KeyCode.JoystickButton13,
        KeyCode.JoystickButton14,
        KeyCode.JoystickButton15,
        KeyCode.JoystickButton16,
        KeyCode.JoystickButton17,
        KeyCode.JoystickButton18,
        KeyCode.JoystickButton19
        };


    // Use this for initialization
    void Start () {

        ChangeToWhiteTest();
        LoadColor();

        firstButton.GetComponent<Button>().Select();
	}

    private void LoadColor()
    {
        background.LoadColor();
    }

    // Update is called once per frame
    void Update () {
        foreach (KeyCode kc in keycodes)
        {
            if (Input.GetKeyDown(kc))
            {
                Debug.Log("Detected: " + kc.ToString());
            }
            
        }


        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            ChangeToWhiteTest();
        }
        else if(Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            ChangeToPurpleTest();
        }
        else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            ChangeToGoldTest();
        }

        LoadColor();
    }

    public void ChangeToWhiteTest()
    {
        BackgroundPrefabManager.CURR_TEST_COLOR = new Color(1, 1, 1, 0.01f);

    }

    public void ChangeToGoldTest()
    {
        BackgroundPrefabManager.CURR_TEST_COLOR = new Color(.94f, 0.85f, 0.2f, 0.01f);

    }

    public void ChangeToPurpleTest()
    {
        BackgroundPrefabManager.CURR_TEST_COLOR = new Color(0.82f, 0.23f, 0.76f, 0.01f);

    }
}
