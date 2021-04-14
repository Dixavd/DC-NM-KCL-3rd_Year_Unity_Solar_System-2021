using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Unity Script will define the InitiaL Conditions of Position and Velocity for an Object in the Scene
public class InitialConditions : MonoBehaviour
{
    // Variables

    public float initialVelocityX = 0.0f;
    public float initialVelocityY = 0.0f;
    public float initialVelocityZ = 0.0f;
    public float initialPositionX = 0.0f;
    public float initialPositionY = 0.0f;
    public float initialPositionZ = 0.0f;
   // public float objectRadius = 0.0f;
    //public float initialTilt = 0.0f;

   // private float G = 2.05088e-05f;
   // private float internalTorque = 0.0f;
   // private Vector3 tiltVector;

    public Rigidbody rb;

    /* OnEnable acts when the object is first initialised into the scene 
       * This is required because it needs to activate before any Gravitational Forces */
    private void OnEnable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(initialVelocityX, initialVelocityY, initialVelocityZ);
        rb.position = new Vector3(initialPositionX, initialPositionY, initialPositionZ);
        //tiltVector = new Vector3(0.0f, initialTilt, 0.0f);
       // rb.transform.eulerAngles = tiltVector;
       // internalTorque = (rb.mass * G) / objectRadius;
       // rb.AddTorque(tiltVector * internalTorque);
    }
}
