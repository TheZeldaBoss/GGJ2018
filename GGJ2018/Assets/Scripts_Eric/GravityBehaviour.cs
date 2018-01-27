using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour {

    public Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * rb.mass);
        //transform.Translate(Vector3.down * rb.mass * Time.deltaTime);
    }
}
