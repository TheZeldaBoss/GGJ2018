using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gestionMenuFin : MonoBehaviour {
    public Button buttonMenu, buttonContinue;
	// Use this for initialization
	void Start () {
		
	}

    void OnEnable()
    {
        //Register Button Events
        buttonMenu.onClick.AddListener(() => buttonCallBack(buttonMenu));
        buttonContinue.onClick.AddListener(() => buttonCallBack(buttonContinue));

    }

    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == buttonMenu)
        {
            //Your code for button 1
            SceneManager.LoadScene("benoit");
        }

        if (buttonPressed == buttonContinue)
        {
            //Your code for button 2
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    void OnDisable()
    {
        //Un-Register Button Events
        buttonContinue.onClick.RemoveAllListeners();
        buttonMenu.onClick.RemoveAllListeners();
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
