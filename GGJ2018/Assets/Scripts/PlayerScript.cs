using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityType { Normal, Reversed, Low, High};
public enum FrictionType { Normal, Glissant, Collant};
public enum ContactType { Normal, Left, Right };

public class PlayerScript : MonoBehaviour {

    public float speed = 3.0f;
    public float speedActive;
    public float gravityValue = 9.81f;
    public float jumpForce = 10f;
    private float jumpActive;

    public bool isGravityReversed = false;

    private float rot = 0;
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

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().useGravity = false;
        jumpActive = jumpForce;
        speedActive = speed;
        slid = Vector3.zero;
}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * gravityValue * (isGravityReversed ? -1 : 1));

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speedActive;
        this.transform.Translate(x, 0, 0);

        //Inertie
        slid = Slidder(slid);
        transform.Translate(slid * Time.deltaTime);

        if (isFalling)
        {
            if (prog <= 0) prog = 0;
            prog = (Time.time - startTime) / stamina;
            Debug.Log(prog);

            if (prog > stamina) prog = 15f;

            Debug.Log(prog);
            if (rot > 0)
            {
                //ContactType.Right:
                rb.AddForce(Vector3.up * (-speedActive) * varcustom * prog);
            }
            else
            {
                if (rot < 0)
                {
                    //ContactType.Left:
                    rb.AddForce(Vector3.up * (-speedActive) * varcustom * prog);
                }
            }
        }
        

        if (transform.Find("feet").GetComponent<FeetScript>().isGrounded)
            rb.velocity = Input.GetAxis("Jump") * jumpActive * transform.up;
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

    public void ChangeFrictionType(FrictionType type)
    {
        switch (type)
        {
            case FrictionType.Normal:
                //Etat par défaut
                inertie = 0f;
                jumpActive = jumpForce;
                collable = false;
                isFalling = false;
                break;

            case FrictionType.Glissant:
                jumpActive = jumpForce; ;
                collable = false;
                isFalling = false;
                break;

            case FrictionType.Collant:
                jumpActive = 0f;
                inertie = 0f;
                collable = true;
                break;
            default:
                break;
        }
    }

    public void surfaceContact(ContactType type)
    {
        switch (type)
        {
            case ContactType.Normal:
                isFalling = false;
                rot = 0;
                speedActive = speed;
                transform.rotation = Quaternion.Euler(0, 0, rot);
                break;

            case ContactType.Left:
                if (collable)
                {
                    isFalling = true;
                    startTime = Time.time;
                    speedActive = speed * slow;
                    rot -= 90;
                    transform.rotation = Quaternion.Euler(0, 0, rot);
                }
                break;

            case ContactType.Right:
                if (collable)
                {
                    isFalling = true;
                    startTime = Time.time;
                    speedActive = speed * slow;
                    rot += 90;
                    transform.rotation = Quaternion.Euler(0, 0, rot);
                    
                }
                break;
            default:
                break;
        }      
    }

    Vector3 Slidder(Vector3 glisseur)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            glisseur = Vector3.left * speedActive;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            glisseur = Vector3.right * speedActive;
        }
        glisseur *= inertie;
        return glisseur;
    }

    void OnCollisionEnter(Collision col) //Si le joueur atteint un sol
    {
        if ((col.gameObject.tag == "Ground") && (collable))
        {
            if (col.contacts[0].point.x > GetComponent<Transform>().position.x + delta)
            {
                surfaceContact(ContactType.Right);
            }
            if ((col.contacts[0].point.x) < GetComponent<Transform>().position.x - delta)
            {
                surfaceContact(ContactType.Left);
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
