// This is a Backup copy of the original GravitationalAttraction script
// This is prior to changing the numbers from floats to doubles and decimals

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*


//  This Unity Script will give objects a Gravitationally Attractive Additive Force 
//  on all other Objects with the same enBLED Script in the Scene.
public class GravitationalAttraction : MonoBehaviour
{
    // Variables

    // Variables used for the scale of the simulation
    // time variable
    public float timeUnit = 17529.4f;       // [s]
    // mass variable
    public float massUnit = 1e+27f;         // [kg]
    // distance variable
    public float distanceUnit = 1e+7f;      // [km]

    // Gravitational constant G inititally in real units   // [m^3 kg^-1 s^-2]
    public float gravitationalConstantG = 6.6743e-11f;

    // Define a non-moving list of all objects with this Gravitational Attraction Script enabled
    // In other words, this will be a list of all Objects with Gravity 
    public static List<GravitationalAttraction> GravityObjects;

    // Define rb as this object's Rigidbody component publicly so other objects can find it
    public Rigidbody rb;

    // OnEnable is called when the assigned object is first initialised
    void OnEnable()
    {

        // find the object with the scaling script attached
        // by default have set it to be on the camera
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("Main Camera");

        // obtain starting value of G
        gravitationalConstantG = scalingObject.GetComponent<Scale>().rescaledG;

        // Create a list of Objects with Gravity if the current one is empty
        if (GravityObjects == null)
            GravityObjects = new List<GravitationalAttraction>();
        // Then add this object to the list of Objects with Gravity
        GravityObjects.Add(this);
        // Confirm in the Debug Log that this Object's Gravity has been enabled
        DebugConfirmation(" is experiencing and exerting Gravitational Forces");
    }

    // FixedUpdate is called at a constant time interval independent of Frame-Rate
    void FixedUpdate()
    {
        // find the object with the scaling script attached
        // by default have set it to be on the camera
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("Main Camera");

        // Update value of Gravitational Constant G
        gravitationalConstantG = scalingObject.GetComponent<Scale>().rescaledG;

        // Systematically go through entire list of Objects with Gravity
        foreach (GravitationalAttraction otherObject in GravityObjects)
        {
            // Ignore self (don't want this object to exert gravity on itself)
            if (otherObject != this)
                // Perform the function to exert a Gravitational Force on each Other Object in the List
                GravitationalForce(otherObject);
        }
    }

    // When Object is removed from the scene or this script is disabled
    void OnDisable()
    {
        // Remove this object from the list of Objects with Gravity
        GravityObjects.Remove(this);
        // Confirm in the Debug Log that this Object's Gravity has been disabled
        DebugConfirmation(" has stopped experiencing and exerting Gravitational Forces");
    }

    // Other Functions that aren't called 

    // Generalised code to Notify the Debug Log of this object along with the message a variable message
    void DebugConfirmation(string x)
    {
        Debug.Log(this + x);
    }

    // Function to create a gravitational force this object experiences due to another mass 
    void GravitationalForce(GravitationalAttraction otherObject)
    {

        // Obtain Rigidbody Properties for the other Object
        Rigidbody rbOtherObject = otherObject.rb;
        // Calculate the vector between This Object's current position and the Other Object's current position
        Vector3 radius = rb.position - rbOtherObject.position;
        // Find the squared distance between the two objects
        float radiussquared = radius.sqrMagnitude;
        // Calculate Magnitude of the Gravitional Force due to: 
        // This Object's Mass, the Other Onject's Mass, and the squared distance between them 
        // Using the Gravitational Proportionality Constant G
        float gravitationalMagnitude = (gravitationalConstantG * rb.mass * rbOtherObject.mass) / radiussquared;
        // Form Gravitational Force by multiplying the Magnitude by the unity/normalised direction of radius
        Vector3 gravitationalForce = gravitationalMagnitude * radius.normalized;
        // Set the Gravitational Force to act on the Other Object 
        // in addition to other forces already acting on that object
        rbOtherObject.AddForce(gravitationalForce);
    }

}
*/



/* This Unity Script will give objects a Gravitationally Attractive Additive Force 
on all other Objects with the same enBLED Script in the Scene. 
public class GravitationalAttraction : MonoBehaviour
{
    // Variables

    // Variables used for the scale of the simulation
    // time variable
    public decimal timeUnit = 17529.4m;         // [s]
    // mass variable
    public decimal massUnit = 1e+22m;           // [kg * 10^-5] shifted to keep in decimal range
    // distance variable
    public decimal distanceUnit = 1e+7m;        // [km]

    // Gravitational constant G inititally in real units   // [m^3 kg^-1 s^-2]
    public decimal gravitationalConstantG = 6.6743015e-11m;

    /* Define a non-moving list of all objects with this Gravitational Attraction Script enabled
     * In other words, this will be a list of all Objects with Gravity
    public static List<GravitationalAttraction> GravityObjects;

    // Define rb as this object's Rigidbody component publicly so other objects can find it
    public Rigidbody rb;

    // OnEnable is called when the assigned object is first initialised
    void OnEnable()
    {

        // find the object with the scaling script attached
        // by default have set it to be on the camera
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("Main Camera");

        // obtain starting value of G
        gravitationalConstantG = scalingObject.GetComponent<Scale>().rescaledG;

        // Create a list of Objects with Gravity if the current one is empty
        if (GravityObjects == null)
            GravityObjects = new List<GravitationalAttraction>();
        // Then add this object to the list of Objects with Gravity
        GravityObjects.Add(this);
        // Confirm in the Debug Log that this Object's Gravity has been enabled
        DebugConfirmation(" is experiencing and exerting Gravitational Forces");
    }

    // FixedUpdate is called at a constant time interval independent of Frame-Rate
    void FixedUpdate()
    {
        // find the object with the scaling script attached
        // by default have set it to be on the camera
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("Main Camera");

        // Update value of Gravitational Constant G
        gravitationalConstantG = scalingObject.GetComponent<Scale>().rescaledG;

        // Systematically go through entire list of Objects with Gravity
        foreach (GravitationalAttraction otherObject in GravityObjects)
        {
            // Ignore self (don't want this object to exert gravity on itself)
            if (otherObject != this)
                // Perform the function to exert a Gravitational Force on each Other Object in the List
                GravitationalForce(otherObject);
        }
    }

    // When Object is removed from the scene or this script is disabled
    void OnDisable()
    {
        // Remove this object from the list of Objects with Gravity
        GravityObjects.Remove(this);
        // Confirm in the Debug Log that this Object's Gravity has been disabled
        DebugConfirmation(" has stopped experiencing and exerting Gravitational Forces");
    }

    // Other Functions that aren't called 

    // Generalised code to Notify the Debug Log of this object along with the message a variable message
    void DebugConfirmation(string x)
    {
        Debug.Log(this + x);
    }

    // Function to create a gravitational force this object experiences due to another mass 
    void GravitationalForce(GravitationalAttraction otherObject)
    {

        // Obtain Rigidbody Properties for the other Object
        Rigidbody rbOtherObject = otherObject.rb;
        // Calculate the vector between This Object's current position and the Other Object's current position
        Vector3 radius = rb.position - rbOtherObject.position;
        // Find the squared distance between the two objects
        float radiussquared = radius.sqrMagnitude;
        /* Calculate Magnitude of the Gravitional Force due to: 
         * This Object's Mass, the Other Onject's Mass, and the squared distance between them 
         * Using the Gravitational Proportionality Constant G 
        float gravitationalMagnitude = ((float)gravitationalConstantG * rb.mass * rbOtherObject.mass) / radiussquared;
        // Form Gravitational Force by multiplying the Magnitude by the unity/normalised direction of radius
        Vector3 gravitationalForce = gravitationalMagnitude * radius.normalized;
        /* Set the Gravitational Force to act on the Other Object 
         * in addition to other forces already acting on that object 
        rbOtherObject.AddForce(gravitationalForce);
    }

} */