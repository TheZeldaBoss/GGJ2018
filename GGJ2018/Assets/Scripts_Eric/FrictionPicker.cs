using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionPicker : MonoBehaviour {

    public FrictionType friction;
    public float inertie = 0;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(this.name);
        GameObject colliderObject = collider.gameObject;
        if (colliderObject.tag == "Player")
        {
            colliderObject.GetComponent<PlayerScript>().ChangeFrictionType(friction);
            colliderObject.GetComponent<PlayerScript>().inertie = inertie;
           Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
