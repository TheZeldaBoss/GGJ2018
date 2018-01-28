using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveScript : MonoBehaviour {

    public GameObject explosion;
    public GameObject projectile;

    public float explosionForce = 25f;
    public float explosionRadius = 10f;

	// Use this for initialization
	void Start () {
        GetComponent<SphereCollider>().radius = explosionRadius;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void explode() {
        GameObject explo = Instantiate(explosion, transform);
        explo.transform.parent = null;
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Explodable")) {
            if (GetComponent<SphereCollider>().bounds.Intersects(go.GetComponent<Collider>().bounds)) {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, go.transform.position, out hit)) {
                    Debug.DrawLine(transform.position, hit.point, Color.red);

                    Debug.Log(hit.point);
                    GameObject instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
                    Rigidbody myRigidbody = instantiatedProjectile.GetComponent<Rigidbody>();
                    myRigidbody.velocity = (hit.point - transform.position).normalized * explosionForce;
                    myRigidbody.rotation = Quaternion.LookRotation(instantiatedProjectile.GetComponent<Rigidbody>().velocity);

                }
            }
        }
        Destroy(transform.parent.gameObject);
    }
}
