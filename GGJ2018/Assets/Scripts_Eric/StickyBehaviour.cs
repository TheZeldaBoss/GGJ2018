using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBehaviour : MonoBehaviour
{
    public PlayerScript ps;
    public bool contact = false;
    private float delta = 0.01f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (contact)
        {
            //GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity/10);//Force AntiGravité V1
            GetComponent<Rigidbody>().AddForce(Vector3.down * ps.gravityValue * 10 * (ps.isGravityReversed ? 1 : -1));
        }
    }


    void OnCollisionEnter(Collision col) //Si le joueur atteint un sol
    {
        if (col.gameObject.tag == "Ground")
        {
            contact = true;
            if (col.contacts[0].point.x > GetComponent<Transform>().position.x+delta)
            {
                ps.surfaceContact(ContactType.Right);
            }
            if ((col.contacts[0].point.x ) < GetComponent<Transform>().position.x-delta)
            {
                ps.surfaceContact(ContactType.Left);
            }
        }

    }
    void OnCollisionExit(Collision col) //Si le joueur atteint un sol
    {
        if (col.gameObject.tag == "Ground")
        {
            contact = false;
            ps.surfaceContact(ContactType.Normal);
        }
    }
}
