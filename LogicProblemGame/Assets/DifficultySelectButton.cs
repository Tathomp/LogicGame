using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectButton : MonoBehaviour {

    public DifficultySelectEnum DifficultySelected;

	public void ButtonClicked(string levelSceneName)
    {
        QuestionSceneManager.CURRENT_DIFFICULTY = DifficultySelected;
        Debug.Log("Player selected " + DifficultySelected + " to play.");
        SceneManager.LoadScene(levelSceneName);
    }
}
