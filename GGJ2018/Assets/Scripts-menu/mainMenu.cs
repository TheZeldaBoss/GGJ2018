using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    public bool isStart = false, isSettings = false, isQuit = false;
	// Use this for initialization
	void Start () {
		
	}
	
    void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene("benoit2");
        }
        if (isQuit)
        {
            Application.Quit();
        }
        
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
