using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectionMenu : MonoBehaviour {

    public bool isLvl1, isLvl2, isLvl3, isLvl4, isLvl5, isLvl6, isLvl7, isLvl8, isLvl9, isLvl10, isLvl11, isLvl12;
	// Use this for initialization
	void Start () {
		
	}
	
    void OnMouseUp()
    {
        if (isLvl1)
            SceneManager.LoadScene("Level1Test");
        if (isLvl2)
            SceneManager.LoadScene("Level2Test");
        if (isLvl3)
            SceneManager.LoadScene("Level3Test");
        if (isLvl4)
            SceneManager.LoadScene("Level4Test");
        if (isLvl5)
            SceneManager.LoadScene("Level5Test");
        if (isLvl6)
            SceneManager.LoadScene("Level6Test");
        if (isLvl7)
            SceneManager.LoadScene("Level7Test");
        if (isLvl8)
            SceneManager.LoadScene("Level8Test");
        if (isLvl9)
            SceneManager.LoadScene("Level9Test");
        if (isLvl10)
            SceneManager.LoadScene("Level10Test");
        if (isLvl11)
            SceneManager.LoadScene("Level11Test");
        if (isLvl12)
            SceneManager.LoadScene("Level12Test");
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
