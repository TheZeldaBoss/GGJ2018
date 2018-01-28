using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilatreurBehaviour : MonoBehaviour {
    //Ventilateur traque les objets liquides (tag ou le booleen du joueur)
    //ColliderBoxSortant des Y positif par defaut
    public float range; // Portée du souffle du ventilateur
    public float power; //Puissance du souffle du ventilateur
    Transform fan;
    // Use this for initialization
    void Start () {
        //Armement du Ventillateur
        fan = this.gameObject.transform.GetChild(0);
        fan.localPosition = Vector3.up * range/2;
        fan.localScale = new Vector3(1,range,1);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
