using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour {

    GameObject joueur;
    /* 1 = Colle
     * 2 = Lourd
     * 3 = Feu
     * 4 = Inverse
     * 5 = liquide
     * 6 = Aimant
     * 7 = Glisse
     * 8 = Leger*/

	// Use this for initialization
	void Start () {
        joueur = GameObject.Find("Player");
        for (int i = 9; i<= 16; i++)
        {
            GameObject.Find("Image (" + i + ")").SetActive(false); //Cache les images visible
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Frictions

        // Si liquide
        if (joueur.GetComponent<PlayerScript>().isCol)
        {
            GameObject.Find("Image(1)").SetActive(false);
            GameObject.Find("Image(9)").SetActive(true);
        }
        else
        {
            GameObject.Find("Image(1)").SetActive(true);
            GameObject.Find("Image(9)").SetActive(false);
        }

        if (joueur.GetComponent<PlayerScript>().isLourd)
        {
            GameObject.Find("Image (2)").SetActive(false);
            GameObject.Find("Image (10)").SetActive(true);
        }
        else
        {
            GameObject.Find("Image (2)").SetActive(true);
            GameObject.Find("Image (10)").SetActive(false);
        }

        if (Utilities.childWithTag(joueur.transform,"Fire"))//Fire
        {
            GameObject.Find("Image (3)").SetActive(false);
            GameObject.Find("Image (11)").SetActive(true);
        }
        else
        {
            GameObject.Find("Image (3)").SetActive(true);
            GameObject.Find("Image (11)").SetActive(false);
        }

        if (joueur.GetComponent<PlayerScript>().isGravityReversed)
        {
            GameObject.Find("Image (4)").SetActive(false);
            GameObject.Find("Image (12)").SetActive(true);
        }
        else
        {
            GameObject.Find("Image (4)").SetActive(true);
            GameObject.Find("Image (12)").SetActive(false);
        }

        if (joueur.GetComponent<PlayerScript>().isLiquid)
        {
            GameObject.Find("Image (5)").SetActive(false);
            GameObject.Find("Image (13)").SetActive(true);
        }
        else
        {
            GameObject.Find("Image (5)").SetActive(true);
            GameObject.Find("Image (13)").SetActive(false);
        }

        /*if (joueur.GetComponent<PlayerScript>().isAim) Pas implémenté
        {
            GameObject.Find("Image (6)").SetActive(false);
            GameObject.Find("Image (14)").SetActive(true);
        }
        else
        {
            GameObject.Find("Image (6)").SetActive(true);
            GameObject.Find("Image (14)").SetActive(false);
        }*/

        if (joueur.GetComponent<PlayerScript>().isGlisse)
        {
            GameObject.Find("Image (7)").SetActive(false);
            GameObject.Find("Image (15)").SetActive(true);
        }
        else
        {
            GameObject.Find("Image (7)").SetActive(true);
            GameObject.Find("Image (15)").SetActive(false);
        }

        if (joueur.GetComponent<PlayerScript>().isLeger)
        {
            GameObject.Find("Image (8)").SetActive(false);
            GameObject.Find("Image (16)").SetActive(true);
        }
        else
        {
            GameObject.Find("Image (6)").SetActive(true);
            GameObject.Find("Image (16)").SetActive(false);
        }
    }
}
