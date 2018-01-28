using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityType { Reversed, Normal, Low, High};
public enum FrictionType { Normal, Glissant, Collant};
public enum ContactType { Normal, Left, Right };


public class PlayerScript : MonoBehaviour {

    public GameObject gravityComponent;

    public float speed = 3.0f;
    public float speedActive;
    public float gravityValue = 9.81f;
    public float jumpForce = 10f;
    private float jumpActive;

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
    public float inertie = 0f;
    private Vector3 slid;
    public bool collable = false;
    public float slow = 0.5f;
    private float delta = 0.25f;

    private bool isFalling = false;
    public float stamina = 15f; //Temps avant la fin de la montée
    private float startTime;
    public float varcustom;

    private float prog = 0f;

    private bool isFrictionEdited = false;
    private float collantTimer = 0f;

    public bool isLiquid = false;
    private float liquidTimer = 0f;

    public GameObject waterComponent;

    // Use this for initialization
    void Start() {
        GetComponent<Rigidbody>().useGravity = false;
        jumpActive = jumpForce;
        speedActive = speed;
        slid = Vector3.zero;
        Physics.IgnoreLayerCollision(4, 9);
    }

    // Update is called once per frame
    void Update() {
        if (isGravityTransferable) {
            timerGravity += Time.deltaTime;
            if (timerGravity >= propertyDuration) {
                changeGravityLevel(GravityType.Normal);
            }
        }
        if (isFrictionEdited) {
            collantTimer += Time.deltaTime;
            if (collantTimer >= propertyDuration) {
                ChangeFrictionType(FrictionType.Normal);
            }
        }

        if (isLiquid) {
            liquidTimer += Time.deltaTime;
            if (liquidTimer >= propertyDuration) {
                setSolid();
            }
        }
    }

    private void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * gravityValue);

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speedActive;
        this.transform.Translate(x, 0, 0);

        //Inertie
        slid = Slidder(slid);
        transform.Translate(slid * Time.deltaTime);

        if (isFalling) {
            if (prog <= 0) prog = 0;
            prog = (Time.time - startTime) / stamina;

            if (rot > 0) {
                //ContactType.Right:
                rb.AddForce(Vector3.up * (-speedActive) * varcustom * prog);
            } else {
                if (rot < 0) {
                    //ContactType.Left:
                    rb.AddForce(Vector3.up * (-speedActive) * varcustom * prog);
                }
            }
        }


        if (transform.Find("feet").GetComponent<FeetScript>().isGrounded)
            rb.velocity = Input.GetAxis("Jump") * jumpActive * transform.up;
    }

    public void changeGravityLevel(GravityType type) {
        myGravity = type;
        switch (type) {
            case GravityType.Normal:
                gravityValue = 9.81f;
                if (isGravityReversed) {
                    reverseGravity();
                }
                isGravityTransferable = false;
                break;
            case GravityType.High:
                if (isGravityReversed) {
                    reverseGravity();
                }
                gravityValue = 20f;
                isGravityTransferable = true;
                break;
            case GravityType.Low:
                if (isGravityReversed) {
                    reverseGravity();
                }
                gravityValue = 5f;
                isGravityTransferable = true;
                break;
            case GravityType.Reversed:
                if (!isGravityReversed) {
                    reverseGravity();
                }
                isGravityTransferable = true;
                gravityValue = -9.81f;
                break;
            default:
                break;
        }

        timerGravity = 0f;
    }

    void reverseGravity() {
        isGravityReversed = !isGravityReversed;
        Camera.main.transform.parent = null;
        transform.Rotate(180f, 0, 0);
        Camera.main.transform.parent = transform;
        Camera.main.GetComponent<CameraScript>().reverseGravity();
    }

    public void ChangeFrictionType(FrictionType type) {
        switch (type) {
            case FrictionType.Normal:
                //Etat par défaut

                isFrictionEdited = false;
                inertie = 0f;
                jumpActive = jumpForce;
                collable = false;
                isFalling = false;
                break;

            case FrictionType.Glissant:
                jumpActive = jumpForce; ;
                collable = false;
                isFalling = false;
                isFrictionEdited = true;
                collantTimer = 0f;
                break;

            case FrictionType.Collant:
                jumpActive = 0f;
                inertie = 0f;
                collable = true;
                isFrictionEdited = true;
                collantTimer = 0f;
                break;
            default:
                break;
        }
    }

    public void surfaceContact(ContactType type) {
        switch (type) {
            case ContactType.Normal:
                isFalling = false;
                rot = 0;
                speedActive = speed;

                Camera.main.transform.parent = null;
                transform.rotation = Quaternion.Euler(0, 0, rot);
                Camera.main.transform.parent = transform;
                break;

            case ContactType.Left:
                if (collable) {
                    isFalling = true;
                    startTime = Time.time;
                    speedActive = speed * slow;
                    rot -= 90;
                    Camera.main.transform.parent = null;
                    transform.rotation = Quaternion.Euler(0, 0, rot);
                    Camera.main.transform.parent = transform;
                }
                break;

            case ContactType.Right:
                if (collable) {
                    isFalling = true;
                    startTime = Time.time;
                    speedActive = speed * slow;
                    rot += 90;
                    Camera.main.transform.parent = null;
                    transform.rotation = Quaternion.Euler(0, 0, rot);
                    Camera.main.transform.parent = transform;

                }
                break;
            default:
                break;
        }
    }

    Vector3 Slidder(Vector3 glisseur) {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            glisseur = Vector3.left * speedActive;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            glisseur = Vector3.right * speedActive;
        }
        glisseur *= inertie;
        return glisseur;
    }

    public void setLiquid() {
        isLiquid = true;
        gameObject.layer = 4;
        foreach (Transform tr in transform) {
            tr.gameObject.layer = 4;
        }
        liquidTimer = 0;
    }

    public void setSolid() {
        isLiquid = false;
        gameObject.layer = 0;
        foreach (Transform tr in transform) {
            tr.gameObject.layer = 0;
        }
    }

    void OnCollisionEnter(Collision col) //Si le joueur atteint un sol
    {
        if ((col.gameObject.tag == "Ground") && (collable)) {
            if (col.contacts[0].point.x > GetComponent<Transform>().position.x + delta) {
                surfaceContact(ContactType.Right);
            }
            if ((col.contacts[0].point.x) < GetComponent<Transform>().position.x - delta) {
                surfaceContact(ContactType.Left);
            }
        }

        Transform objectHit = col.transform;

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

        if (isLiquid && objectHit.tag == "PropertySensitive") {
            Transform waterInstance = Utilities.childWithTag(objectHit, "Water");
            if (!waterInstance) {
                waterInstance = Instantiate(waterComponent, objectHit).transform;
                waterInstance.parent = objectHit;
            }
        }

    }
    void OnCollisionExit(Collision col) //Si le joueur atteint un sol
    {
        if ((col.gameObject.tag == "Ground") && (collable))
        {
            surfaceContact(ContactType.Normal);
        }
    }
}
