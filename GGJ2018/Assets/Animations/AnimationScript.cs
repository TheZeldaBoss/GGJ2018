using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    Animator anim;
    PlayerScript player;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);

        float moveVertical = transform.GetComponent<Rigidbody>().velocity.y;
        anim.SetFloat("VerticalVelocity", moveVertical);

        anim.SetBool("isLiquid", player.isLiquid);

        
    }
}
