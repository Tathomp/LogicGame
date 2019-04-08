using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelectManager : MonoBehaviour {

    public DifficultySelectButton firstButton; 

	// Use this for initialization
	void Start () {
        firstButton.GetComponent<Button>().Select();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
