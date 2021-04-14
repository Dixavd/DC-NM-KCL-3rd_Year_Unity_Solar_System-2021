using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Unity Script will give objects a Gravitationally Attractive Additive Force 
// on all other Objects with the same enabled Script in the Scene.
public class GravitationalAttraction : MonoBehaviour
{
    // Variables

    // Gravitational constant G inititally in real units   // [m^3 kg^-1 s^-2]
    public decimal gravitationalConstantG = 6.6743015e-11m;

    // Define a non-moving list of all objects with this Gravitational Attraction Script enabled
    // In other words, this will be a list of all Objects with Gravity 
    public static List<GravitationalAttraction> GravityObjects;

    // Define rb as this object's Rigidbody component publicly so other objects can find it
    public Rigidbody rb;

    // This object's SphereCollider
    public SphereCollider sc;

    // variable to be true when gravity should be calculated
    public bool runGravity = false;

    // Object which determines scale of simulation
    private GameObject scalingObject;

    // This CoRoutine waits until another script changes the runGravity check to true before allowing this object to experience and cause gravity
    // This means a new object will not affect other objects until another script has confirmed it is ready to do so
    IEnumerator WaitConfirmation() 
    {
        // Wait until runGravity check has been set to true by another script
        yield return new WaitUntil(() => runGravity == true);

        // Then add this object to the list of Objects with Gravity
        GravityObjects.Add(this);

        // Confirm in the Debug Log that this Object's Gravity has been enabled
        DebugConfirmation(" has been added to the list of Gravitational objects");
    }


    // Awake is the earliest possible event
    // Awake occurs before OnEnable
    void Awake()
    {
        // Set runGavity check to false first
        // It will be set to true by another script once the object is ready to experience and cause 
        runGravity = false;

        // Label this object's Rigidbody Component
        rb = this.GetComponent<Rigidbody>();
        // Label this object's Sphere Collider Component
        sc = this.GetComponent<SphereCollider>();

        // find the object with the scaling script attached
        scalingObject = GameObject.Find("ScaleScriptObject");

        // obtain starting value of G
        gravitationalConstantG = scalingObject.GetComponent<Scale>().rescaledG;

        // Create a list of Objects with Gravity if the current one is empty
        if (GravityObjects == null)
        {
            GravityObjects = new List<GravitationalAttraction>();
        }

        // Start CoRoutine to wait until runGravity is true before adding this object to the list of objects causing gravity
        StartCoroutine("WaitConfirmation");
    }

    // FixedUpdate is called at a constant time interval independent of Frame-Rate
    void FixedUpdate()
    {
        // Only calculate Gravity if it should be running
        if (runGravity == true) 
        {
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
        // Specify the Rigidbody component of this object
        Rigidbody rb = this.GetComponent<Rigidbody>();
        // Obtain Rigidbody Properties for the other Object
        Rigidbody rbOtherObject = otherObject.GetComponent<Rigidbody>();
        // Calculate the vector between This Object's current position and the Other Object's current position
        Vector3 radius = rb.position - rbOtherObject.position;
        // Find the squared distance between the two objects
        float radiussquared = radius.sqrMagnitude;
        // Calculate Magnitude of the Gravitional Force due to: 
        // This Object's Mass, the Other Onject's Mass, and the squared distance between them 
        // Using the Gravitational Proportionality Constant G
        float gravitationalMagnitude = ((float)gravitationalConstantG * rb.mass * rbOtherObject.mass) / radiussquared;
        // Form Gravitational Force by multiplying the Magnitude by the unity/normalised direction of radius
        Vector3 gravitationalForce = gravitationalMagnitude * radius.normalized;
        // Set the Gravitational Force to act on the Other Object 
        // in addition to other forces already acting on that object
        rbOtherObject.AddForce(gravitationalForce);
    }

}
