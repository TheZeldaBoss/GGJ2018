using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityType { Normal, Reversed, Low, High};

public class PlayerScript : MonoBehaviour {

    public float speed = 3.0f;
    public float gravityValue = 9.81f;
    public float jumpForce = 10f;

    private bool isGravityReversed = false;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().useGravity = false;
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * gravityValue * (isGravityReversed ? 1 : -1) );

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        this.transform.Translate(x, 0, 0);

        if(transform.Find("feet").GetComponent<FeetScript>().isGrounded)
            rb.velocity = new Vector3(0, Input.GetAxis("Jump") * jumpForce * (isGravityReversed ? -1 : 1), 0);
    }

    public void changeGravityLevel(GravityType type) {
        switch (type) {
            case GravityType.Normal:
                gravityValue = 9.81f;
                break;
            case GravityType.Reversed:
                isGravityReversed = !isGravityReversed;
                Camera.main.transform.parent = null;
                transform.Rotate(180f, 0, 0);
                Camera.main.transform.parent = transform;
                Camera.main.GetComponent<CameraScript>().reverseGravity();

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
