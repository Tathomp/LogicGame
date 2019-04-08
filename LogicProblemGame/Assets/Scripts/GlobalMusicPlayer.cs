using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicPlayer : MonoBehaviour
{
    public static GlobalMusicPlayer instance;

    // Start is called before the first frame update
    void Start()
    {
        //Basically, we want the music player to presist through the program
        // but we don't want a new one to spawn every time we come back to the 
        // Select screen
        //
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
