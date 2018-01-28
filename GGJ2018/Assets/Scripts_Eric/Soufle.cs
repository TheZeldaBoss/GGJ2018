using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soufle : MonoBehaviour {

    public bool locked = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        locked = false;
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PropertySensitive" || other.gameObject.tag == "Player")
        {
            RaycastHit hit;
            Transform hitBody = other.transform;
            Vector3 rayDirection = transform.parent.position - hitBody.position;

            if (Physics.Raycast(hitBody.position, rayDirection, out hit))
            {
                if (hit.transform == transform.parent)
                {
                    if (childWithTagExists(hitBody, "Water"))
                    {
                        repulse(hitBody, rayDirection);
                    }
                }
                if (other.gameObject.tag == "Player")
                {
                    if (other.GetComponent<PlayerScript>().isLiquid)
                    {
                        repulse(hitBody, rayDirection);
                    }
                }
            }
        }
    }

    bool childWithTagExists(Transform parentToCheck, string tag)
    {
        foreach (Transform child in parentToCheck)
        {
            if (child.tag == tag)
            {
                return true;
            }
        }
        return false;
    }

    void repulse(Transform target, Vector3 direction)
    {
        Debug.Log(direction);
        Vector3 trajectoire = -direction * GetComponentInParent<VentilatreurBehaviour>().power * Time.deltaTime;
        target.Translate(new Vector3(trajectoire.x, trajectoire.y));
    }
}
