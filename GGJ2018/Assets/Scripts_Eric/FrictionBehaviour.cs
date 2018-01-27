using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionBehaviour : MonoBehaviour {

    public float inertie = 0.975f; //Glissade
    public PlayerScript papillon;
    private Vector3 slid;
    public Rigidbody rb;
    public bool slidding = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        slid = Vector3.zero;
        
    }
	
	// Update is called once per frame
	void Update () {
        // Glissade
        slid = Slidder(slid);
        transform.Translate(slid * Time.deltaTime);
    }

    Vector3 Slidder(Vector3 glisseur)
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            glisseur = Vector3.left * papillon.speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            glisseur = Vector3.right * papillon.speed;
        }
        glisseur *= inertie;
        return glisseur;
    }
}
