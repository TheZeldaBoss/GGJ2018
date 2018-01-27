using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetScript : MonoBehaviour {

    public bool isGrounded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Ground") {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        isGrounded = false;
    }
}
