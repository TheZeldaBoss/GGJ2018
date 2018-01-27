using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourPlayer : MonoBehaviour
{
    //
    public float speed = 10f;
    public Rigidbody rb;

    public float jumpTime = 0.05f;
    public float jumpActive = 0f;
    public float jumpHeight = 0.1f;

    public bool OnFloor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Deplacement
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.position = new Vector3(transform.position.x + translation, transform.position.y, transform.position.z);
        
        // Le saut
        if ((jumpActive > 0f) || ((Input.GetKeyDown(KeyCode.Space)) && OnFloor))
        {
            if (jumpActive <= 0f)
            {
                jumpActive = jumpTime;
                OnFloor = false; //Quitte le sol en sautant
            }
            else
            {
                jumpActive -= Time.deltaTime;
            }
            transform.Translate(Vector3.up * jumpHeight);
        }
        
    }

    void OnCollisionEnter(Collision col) //Si le joueur atteint un sol
    {
        if (col.gameObject.tag == "Ground")
        {
            OnFloor = true;
        }
    }


}
