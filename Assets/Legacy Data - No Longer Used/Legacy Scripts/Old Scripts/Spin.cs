using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
    //a script that gives each object in the solar system a rotation about its axis

{
    //defining components that will be called in the script

    public Rigidbody rb;
    public Vector3 eulerAngleVelocity;

    //setting the variables 

    //each objects requires an input of their obliquity (tilt of rotational axis wrt the axis perpendicular to the orbital plane)
    public float obliquityAngle = 0.0f;

    /*each object requires an input of their angular velocity in UNITY units deg/sec 
    /(HERE IT IS PURELY NUMERICAL BUT THE UNITS WILL BE ADDED IN THE FORMULA BELOW BUT NEED TO INPUT THE RIGHT VALUE ASSUMING WITH UNITS)*/
    public float rotationalVelocity = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //fetching the Rigidbody components of objects
        rb = GetComponent<Rigidbody>();

        /*setting the angular velocity of the Rigidbody using the input value above 
        (THIS IS WHERE THE UNITS COME IN - the variable type is in deg/sec for the chosen rotational axis)*/
        eulerAngleVelocity = new Vector3(0, 0, rotationalVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //stores the rotation variable for each object
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);

        //creates the rotation of the object
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

}
