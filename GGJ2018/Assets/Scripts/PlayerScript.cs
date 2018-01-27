using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityType { Normal, Low, High, Reversed };
public enum ContactType { Normal, Left, Right };


public class PlayerScript : MonoBehaviour {

    public GameObject gravityComponent;

    public float speed = 3.0f;
    public float gravityValue = 9.81f;
    public float jumpForce = 10f;

    public bool isGravityReversed = false;

    private float rot = 0;
    private float move = 1;

    public bool isGravityTransferable = false;
    public bool isFrictionTransferable = false;

    public float propertyDuration = 10f;
    float timerGravity = 0f;
    float timerFriction = 0f;
    GravityType myGravity = GravityType.Normal;



    /*MOVE :
     * 1 direction normal
     * -1 direction inversé.
     * */

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().useGravity = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isGravityTransferable) {
            timerGravity += Time.deltaTime;
            if(timerGravity >= propertyDuration) {
                changeGravityLevel(GravityType.Normal);
            }
        }
    }

    private void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * gravityValue);

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        this.transform.Translate(x, 0, 0);

        if(transform.Find("feet").GetComponent<FeetScript>().isGrounded)
            rb.velocity = Input.GetAxis("Jump") * jumpForce * transform.up;
    }

    public void changeGravityLevel(GravityType type) {
        myGravity = type;
        switch (type) {
            case GravityType.Normal:
                gravityValue = 9.81f;
                if (isGravityReversed) {
                    isGravityReversed = false;
                    Camera.main.transform.parent = null;
                    transform.Rotate(180f, 0, 0);
                    Camera.main.transform.parent = transform;
                    Camera.main.GetComponent<CameraScript>().reverseGravity();
                    isGravityTransferable = false;
                }
                break;
            case GravityType.High:
                gravityValue = 20f;
                isGravityTransferable = true;
                break;
            case GravityType.Low:
                gravityValue = 5f;
                isGravityTransferable = true;
                break;
            case GravityType.Reversed:
                if (!isGravityReversed) {
                    isGravityReversed = true;
                    Camera.main.transform.parent = null;
                    transform.Rotate(180f, 0, 0);
                    Camera.main.transform.parent = transform;
                    Camera.main.GetComponent<CameraScript>().reverseGravity();
                }
                isGravityTransferable = true;
                gravityValue = -9.81f;
                break;
            default:
                break;
        }

        timerGravity = 0f;
    }

    public void surfaceContact(ContactType type)
    {
        switch (type)
        {
            case ContactType.Normal:
                rot = 0;
                move = 1;
                transform.rotation = Quaternion.Euler(0, 0, rot);
                break;
            case ContactType.Left:
                rot -= 90;
                transform.rotation = Quaternion.Euler(0, 0, rot);
                break;
            case ContactType.Right:
                rot += 90;
                move = -1;
                transform.rotation = Quaternion.Euler(0, 0, rot);
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Transform objectHit = collision.transform;
        if (isGravityTransferable && objectHit.tag == "PropertySensitive") {
            if (objectHit.GetComponent<GravityComponent>()) {
                if (!objectHit.GetComponent<GravityComponent>().isEmmitter) {
                    objectHit.GetComponent<GravityComponent>().changeGravityLevel(myGravity);
                }
            } else {
                Transform gravityInstance = Utilities.childWithTag(objectHit, "Gravity");
                if (!gravityInstance) {
                    gravityInstance = Instantiate(gravityComponent, objectHit).transform;
                    gravityInstance.parent = objectHit;
                }
                gravityInstance.GetComponent<GravityComponent>().changeGravityLevel(myGravity);
            }
        }
    }
}
