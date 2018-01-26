using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider collider) {
        GameObject colliderObject = collider.gameObject;
        if(colliderObject.tag == "Player") {
            colliderObject.GetComponent<PlayerScript>().changeGravityLevel(GravityType.Reversed);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
