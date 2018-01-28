using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

    public bool isEmitter = false;

	// Use this for initialization
	void Start () {
        transform.parent.gameObject.layer = 4;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision) {
        Transform hitTransform = collision.transform;
        if(isEmitter) {
            if(hitTransform.tag == "Player") {
                hitTransform.GetComponent<PlayerScript>().setLiquid();
            }
        }
        Transform fireChild = Utilities.childWithTag(hitTransform, "Fire");
        if (fireChild && !fireChild.GetComponent<FireScript>().isBaseEmmitter) {
            Destroy(fireChild.gameObject);
        }
    }

    public void setSolid() {
        transform.parent.gameObject.layer = 0;
        Destroy(this);
    }
}
