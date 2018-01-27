using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityType { Normal, Reversed, Low, High};
public enum FrictionType { Normal, Silder, Tights}
public enum ContactType { Normal, Left, Right };

public class PlayerScript : MonoBehaviour
{

    public float speed = 3.0f;
    public float gravityValue = 9.81f;
    public bool isGravityReversed = false;

    public float rot = 0;
    public float move = 1; //1 direction normal, -1 direction inversé.

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        //
        GetComponent<Rigidbody>().AddForce(Vector3.up * gravityValue * (isGravityReversed ? 1 : -1));
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        this.transform.Translate(x, 0, 0);

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        }
    }

    public void changeGravityLevel(GravityType type)
    {
        switch (type)
        {
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

    public void changeFrictionType(FrictionType type)
    {
        switch (type)
        {
            case FrictionType.Normal:
                break;
            case FrictionType.Silder:
                break;
            case FrictionType.Tights:
                break;

        }
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
}
