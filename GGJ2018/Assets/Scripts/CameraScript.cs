using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float translatePercentage = 0;
    public float translateDistance = 5f;
    public float timeForTranslation = 1f;

    bool isPlayerOnTop = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerOnTop && translatePercentage < 1) {
            float actualPercentage = Mathf.Min(100 - translatePercentage, Time.deltaTime / timeForTranslation);
            Debug.Log(actualPercentage);
            translatePercentage += actualPercentage;
            transform.Translate(new Vector3(0, -(actualPercentage) * translateDistance, 0));
        } else if (!isPlayerOnTop && translatePercentage > 0) {
            float actualPercentage = Mathf.Min(translatePercentage, Time.deltaTime / timeForTranslation);
            translatePercentage -= actualPercentage;
            transform.Translate(new Vector3(0, (actualPercentage) * translateDistance, 0));
        }

	}

    public void reverseGravity() {
        isPlayerOnTop = !isPlayerOnTop;
    }
}
