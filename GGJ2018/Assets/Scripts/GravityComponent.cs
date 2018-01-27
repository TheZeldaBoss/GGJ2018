using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityComponent : MonoBehaviour {

    Rigidbody parentRb;

    public bool isEmmitter = false;

    float gravityValue = 9.81f;
    public bool isGravityReversed = false;

    public GravityType gravityType = GravityType.Normal;

	// Use this for initialization
	void Start () {
        parentRb = transform.parent.GetComponent<Rigidbody>();
        parentRb.useGravity = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        parentRb.AddForce(Vector3.down * gravityValue);
    }

    public void changeGravityLevel(GravityType type) {
        switch (type) {
            case GravityType.Normal:
                gravityValue = 9.81f;
                if (isGravityReversed) {
                    transform.Rotate(180f, 0, 0);
                    isGravityReversed = false;
                }
                break;
            case GravityType.High:
                gravityValue = 20f;
                if (isGravityReversed) {
                    transform.Rotate(180f, 0, 0);
                    isGravityReversed = false;
                }
                break;
            case GravityType.Low:
                gravityValue = 3f;
                if (isGravityReversed) {
                    transform.Rotate(180f, 0, 0);
                    isGravityReversed = false;
                }
                break;
            case GravityType.Reversed:
                gravityValue = -9.81f;
                if (!isGravityReversed) {
                    transform.Rotate(180f, 0, 0);
                    isGravityReversed = true;
                }
                break;
            default:
                break;
        }
        gravityType = type;
    }

    private void OnTriggerEnter(Collider other) {
        Transform otherTransform = other.transform;
        if(otherTransform.tag == "Player") {
            otherTransform.GetComponent<PlayerScript>().changeGravityLevel(gravityType);
        }
    }


}
