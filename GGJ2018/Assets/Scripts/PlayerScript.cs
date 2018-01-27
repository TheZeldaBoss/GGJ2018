using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityType { Normal, Reversed, Low, High};

public class PlayerScript : MonoBehaviour {

    public float speed = 3.0f;
    public float gravityValue = 9.81f;
    public bool isGravityReversed = false;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().useGravity = false;
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void FixedUpdate() {
        GetComponent<Rigidbody>().AddForce(Vector3.up * gravityValue * (isGravityReversed ? 1 : -1) );

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        this.transform.Translate(x, 0, 0);


    }

    public void changeGravityLevel(GravityType type) {
        switch (type) {
            case GravityType.Normal:
                gravityValue = 9.81f;
                break;
            case GravityType.Reversed:
                isGravityReversed = !isGravityReversed;
                break;
            case GravityType.High:
                gravityValue = 20f;
                break;
            case GravityType.Low:
                gravityValue = 3f;
                break;
            default:
                break;
        }
    }
}
