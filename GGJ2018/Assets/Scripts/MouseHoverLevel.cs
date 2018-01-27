using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverLevel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnMouseEnter()
    {
        transform.Rotate(0, 3, 0);
    }

    void OnMouseExit()
    {
        transform.Rotate(0, -3, 0);
    }
}
