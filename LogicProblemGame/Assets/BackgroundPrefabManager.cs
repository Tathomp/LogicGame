using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPrefabManager : MonoBehaviour
{
    public static Color CURR_TEST_COLOR = new Color(1, 1, 1, 0.01f);

    // Start is called before the first frame update
    void Start()
    {
        LoadColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadColor()
    {
        Camera.main.backgroundColor = CURR_TEST_COLOR;
    }
}
