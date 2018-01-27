using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour {
    public GameObject endOfLevelWindow;
	// Use this for initialization
	void Start () {
        endOfLevelWindow.SetActive(false);
	}

    private void OnTriggerEnter(Collider collider)
    {
        endOfLevelWindow.SetActive(true);
    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
