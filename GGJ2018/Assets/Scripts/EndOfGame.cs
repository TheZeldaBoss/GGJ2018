using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndOfGame : MonoBehaviour {

    public bool isMenu, isQuit;
	// Use this for initialization
	void Start () {
		
	}

    void OnMouseUp()
    {
        if (isMenu)
        {
            SceneManager.LoadScene("benoit");
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
