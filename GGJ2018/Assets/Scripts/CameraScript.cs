using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    float translatePercentageGravity = 0;
    public float translateDistanceGravity = 5f;
    public float timeForTranslationGravity = 1f;

    public float jumpMoveStrength = 0.001f;
    public float maxHeightJump = 2f;

    bool isPlayerOnTop = false;
    bool isJumping = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isPlayerOnTop && translatePercentageGravity < 1) {
            float actualPercentage = Mathf.Min(1 - translatePercentageGravity, Time.deltaTime / timeForTranslationGravity);
            translatePercentageGravity += actualPercentage;
            transform.Translate(new Vector3(0, -(actualPercentage) * translateDistanceGravity, 0));
        } else if (!isPlayerOnTop && translatePercentageGravity > 0) {
            float actualPercentage = Mathf.Min(translatePercentageGravity, Time.deltaTime / timeForTranslationGravity);
            translatePercentageGravity -= actualPercentage;
            transform.Translate(new Vector3(0, (actualPercentage) * translateDistanceGravity, 0));
        }//else if (isJumping){
         //   transform.Translate(new Vector3(0, -jumpMoveStrength*transform.parent.GetComponent<Rigidbody>().velocity.y, 0));
        //}
    }

    public void reverseGravity() {
        isPlayerOnTop = !isPlayerOnTop;
    }

    public void jump() {
        isJumping = true;
    }

    public void stopJump() {
        isJumping = false;
    }
}
