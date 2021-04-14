using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPosition : MonoBehaviour
{// Variables
    // Create a public Variable which can be assigned to a given Star to follow
    public GameObject Star;
    // FixedUpdate is called at a constant rate
    void FixedUpdate()
    {
        // FixedUpdate is called at a constant time interval independent of Frame-Rate
        this.transform.position = Star.transform.position;
    }
}
