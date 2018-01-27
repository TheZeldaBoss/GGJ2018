using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public float fireRadius = 2f;
    public float propagateFireDelay = 2.0f;
    bool canPropagateFireNow = false;
    public bool isBaseEmmitter = false;

    public float timeToConsume = 6f;


    float propagateFireTimer = 0f;

    // Use this for initialization
    void Start () {
        GetComponent<SphereCollider>().radius = fireRadius;
        if(transform.parent.tag == "Player" || Utilities.childWithTag(transform.parent, "Unflammable")) {
            Destroy(gameObject, timeToConsume);
        } else if (!isBaseEmmitter){ 
            Destroy(transform.parent.gameObject, timeToConsume);
        }
	}

    void changeFireRadius(float newRadius) {
        GetComponent<SphereCollider>().radius = newRadius;
    }

    private void OnTriggerStay(Collider other) {
        if (canPropagateFireNow && other.gameObject.tag == "PropertySensitive" || other.gameObject.tag == "Player") {
            RaycastHit hit;
            Transform collidedTransform = other.transform;
            Vector3 rayDirection = transform.parent.position - collidedTransform.position;
            if (Physics.Raycast(collidedTransform.position, rayDirection, out hit)) {
                if (hit.transform == transform.parent) {
                    if (!Utilities.childWithTag(collidedTransform, "Fire")) {
                        GameObject transmittedFire = Instantiate(gameObject, collidedTransform);
                        transmittedFire.transform.position = collidedTransform.position;
                        transmittedFire.GetComponent<FireScript>().isBaseEmmitter = false;
                        transmittedFire.transform.parent = collidedTransform;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (!canPropagateFireNow && propagateFireDelay > propagateFireTimer) {
            propagateFireTimer += Time.deltaTime;
            if (propagateFireDelay <= propagateFireTimer) {
                canPropagateFireNow = true;
            }
        }
	}
}
