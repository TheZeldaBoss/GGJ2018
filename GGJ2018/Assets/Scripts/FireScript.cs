using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    float fireRadius = 2f;

	// Use this for initialization
	void Start () {
        GetComponent<CircleCollider2D>().radius = fireRadius;
	}

    void changeFireRadius(float newRadius) {
        GetComponent<CircleCollider2D>().radius = newRadius;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
