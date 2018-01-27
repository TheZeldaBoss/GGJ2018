using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities  {

    public static Transform childWithTag(Transform parentToCheck, string tag) {
        foreach (Transform child in parentToCheck) {
            if (child.tag == tag) {
                return child;
            }
        }
        return null;
    }
}
