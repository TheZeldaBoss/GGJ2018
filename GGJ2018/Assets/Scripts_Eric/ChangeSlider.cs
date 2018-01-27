using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSlider : MonoBehaviour {
    public float newSlider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col) //Si le joueur atteint un sol
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<FrictionBehaviour>().inertie = newSlider;
            //0.975 pour une glissade normal
            //0 pour aucune glissade
        }
    }
}
