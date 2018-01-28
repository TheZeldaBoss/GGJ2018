using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverMenu : MonoBehaviour {
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseEnter()
    {
        transform.Rotate(0, 3, 0);
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit()
    {
        transform.Rotate(0, -3, 0);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
